using System;
using UnityEngine;
using UnityEngine.UI;
using WonderGame.Game;

namespace WonderGame.UI.Game {
    public class UITimer : MonoBehaviour {
        [SerializeField] private GameState _gameState;
        [SerializeField] private Text _text;

        // kiírjuk az időt PP : MM formátumban
        private void Update() {
            var time = TimeSpan.FromSeconds(_gameState.TimeSeconds);
            _text.text = $"{time.Minutes:D2} : {time.Seconds:D2}";
        }
    }
}
