using UnityEngine;
using UnityEngine.AI;
using WonderGame.Common;
using Zenject;
#pragma warning disable 649

namespace WonderGame.Game {
    public class EnemyMove : MonoBehaviour {
        [Inject] private NavMeshAgent _navMeshAgent;
        [Inject(Id = "Player")] private Transform _player;
        [Inject] private readonly PlayerInventory _playerInventory;
    
        private void Start() {
            var gameSettingsManager = FindObjectOfType<GameSettingsManager>();
            var difficulty = gameSettingsManager.GameSettings.Difficulty;
            _navMeshAgent.speed *= 1 + 0.1f * difficulty;
        }

        private void Update() {
            // minden pillanatban a játékos pozíciója a célja a zombinak
            _navMeshAgent.SetDestination(_player.position);
        }

        private void OnTriggerEnter(Collider other) {
            // ha elkapott egy játékost (= ütközött egy játékos taggel rendelkező colliderrel)
            // a játékostól elveszünk egy pontot
            if (other.CompareTag("Player")) {
                if (_playerInventory.PickupCount > 0)
                    _playerInventory.PickupCount--;
                Debug.Log("Zombie elkapta a játékost!");
            }
        }
    }
}
