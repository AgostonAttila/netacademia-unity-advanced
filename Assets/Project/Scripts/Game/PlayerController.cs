using System.Collections.Generic;
using Cinemachine;
using DarkRift.Client;
using DarkRift.Client.Unity;
using UnityEngine;
using Zenject;

namespace WonderGame.Game {
    public class PlayerController : MonoBehaviour {
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;    // virtuális kamera (ami követi majd a játékos objektumot)
        [SerializeField] private GameObject _playerPrefab;        // saját játékosunk prefabje
        [SerializeField] private GameObject _otherPlayerPrefab;   // többi játékos prefabje (nem reagál a felhaszálói inputra)

        [Inject] private UnityClient _client;    // hálózati kliens
        
        private readonly Dictionary<ushort, Transform> _networkPlayers = new Dictionary<ushort, Transform>();

        private void Awake() {
            // üzenet érkezésére eseménykezelők
            _client.MessageReceived += SpawnPlayer;
            _client.MessageReceived += MovePlayer;
        }

        // játékos mozgás típusú üzenetek kezelésére
        private void MovePlayer(object sender, MessageReceivedEventArgs e) {
            using (var message = e.GetMessage())
            using (var reader = message.GetReader()) {
                if (message.Tag == 1) {    // 1-es tag: játékos mozgás
                    while (reader.Position < reader.Length) {
                        // beolvassuk az üzenet tartalmát
                        var id = reader.ReadUInt16();
                        var position = new Vector3(reader.ReadSingle(), 0, reader.ReadSingle());
                        var rotation = Quaternion.Euler(0, reader.ReadSingle(), 0);

                        // ha van játékos megfelelő ID-val, mozgatjuk
                        if (_networkPlayers.ContainsKey(id)) {
                            _networkPlayers[id].position = position;
                            _networkPlayers[id].rotation = rotation;
                        }
                    }
                }
            }
        }

        // játékos csatlakozása típusú üzenetek kezelésére
        private void SpawnPlayer(object sender, MessageReceivedEventArgs e) {
            using (var message = e.GetMessage())
            using (var reader = message.GetReader()) {
                if (message.Tag == 0) {    // 0-ás tag: játékos csatlakozott
                    while (reader.Position < reader.Length) {
                        // beolvassuk az üzenet tartalmát
                        var id = reader.ReadUInt16();
                        var position = new Vector3(reader.ReadSingle(), 0, reader.ReadSingle());
                        var rotation = Quaternion.Euler(0, reader.ReadSingle(), 0);

                        // létrehozzuk a megfelelő játékos objektumot
                        GameObject player;
                        if (id == _client.ID) {    // ha a lokoláis játékos
                            player = Instantiate(_playerPrefab, position, rotation);
                            _virtualCamera.Follow = player.transform;
                            _virtualCamera.LookAt = player.transform;
                        } else {    // ha más játékos
                            player = Instantiate(_otherPlayerPrefab, position, rotation);
                        }
                        
                        // beregisztráljuk a játékost
                        _networkPlayers.Add(id, player.transform);
                    }
                }
            }
        }
    }
}