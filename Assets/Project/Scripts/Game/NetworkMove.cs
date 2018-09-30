using DarkRift;
using DarkRift.Client.Unity;
using UnityEngine;
using Zenject;

namespace WonderGame.Game {
    public class NetworkMove : MonoBehaviour {
        [SerializeField] private float _moveDeltaThreshold;    // az a minimum elmozdulás, amiről értesítjük a szervert
        
        [Inject] private readonly UnityClient _client;         // hálózati kliens
        
        private Vector3 _lastPosition;    // legútóbbi elküldött pozíció (ehhez nézzük az elmozdulást)

        private void Awake() {
            _lastPosition = transform.position;
        }

        private void Update() {
            if (Vector3.Distance(_lastPosition, transform.position) > _moveDeltaThreshold) {    // ha az elmozdulás nagyobb, mint a küszöbérték
                // elküldjük az X, Z pozíciót, és az Y rotációt a szervernek
                using (var writer = DarkRiftWriter.Create()) {
                    writer.Write(transform.position.x);
                    writer.Write(transform.position.z);
                    writer.Write(transform.rotation.eulerAngles.y);

                    using (var message = Message.Create(1, writer)) {
                        _client.SendMessage(message, SendMode.Unreliable);    // Unreliable: UDB (kisebb hálózati overhead)
                    }
                }

                _lastPosition = transform.position;    // elmentjük, hogy melyik pozíciót küldtük el legutóbb
            }
        }
    }
}