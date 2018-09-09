using UnityEngine;
using UnityEngine.UI;
using WonderGame.Game;
using WonderGame.HighScores;
using WonderGame.UI.Common;
using Zenject;

namespace WonderGame.UI.Game {
    public class EnterNameUIWindow : UIWindow {
        [SerializeField] private Text _scoreText;
        [SerializeField] private InputField _nameInputField;
        [SerializeField] private GameState _gameState;

        // mivel a játék SceneContextbe is betöltjük a HighScoresInstallert
        // ezért az ott lévő osztályok is elérik a HighScoresControllert, Singleton osztályként
        [Inject] private readonly HighScoresController _highScoresController;

        private bool _isShown;
        private int _score;

        public override void Show() {
            base.Show();
            _score = _gameState.Score;
            _scoreText.text = $"You have gained {_score} points.";
        }

        private void Update() {
            if (_gameState.CannotWin && !_isShown) {
                _isShown = true;
                Show();
            }
        }

        public void OnSubmitClick() {
            var playerName = _nameInputField.text;

            // ha nem üres string a játékos neve, akkor létrehozunk egy bejegyzést a high scores listába
            if (!string.IsNullOrEmpty(playerName) && _score != 0) {
                _highScoresController.AddHighScore(playerName, _score);
            } 
        }
    }
}
