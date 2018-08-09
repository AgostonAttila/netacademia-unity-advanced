using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class EnterNameUIWindow : UIWindow {
    [SerializeField] private Text _scoreText;
    [SerializeField] private InputField _nameInputField;
    [SerializeField] private GameState _gameState;

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
            var newRecord = new ScoreRecord {Name = playerName, Score = _score};
            var highScores = JsonConvert.DeserializeObject<List<ScoreRecord>>(PlayerPrefs.GetString("highScores", "[]"));
            highScores.Add(newRecord);
            highScores = highScores
                .OrderByDescending(r => r.Score)
                .ToList();

            PlayerPrefs.SetString("highScores", JsonConvert.SerializeObject(highScores));
        } 
    }
}
