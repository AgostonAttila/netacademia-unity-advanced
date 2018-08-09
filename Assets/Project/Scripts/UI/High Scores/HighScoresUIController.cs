using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class HighScoresUIController : MonoBehaviour {
    [SerializeField] private Transform _content;
    [SerializeField] private UIScoreRecord _scoreRecordPrefab;
    [SerializeField] private UIWindow _window;

    // megjelenítjuk az ablakot, betöltjük és megjelenítjük a pontszámokat
    private void Start() {
        _window.Show();

        ShowScores(Scores);
    }

    // pontszámok megjelenítése (1 prefab példány 1 pontszámot jelenít meg)
    private void ShowScores(IEnumerable<ScoreRecord> scores) {
        foreach (var scoreRecord in scores) {
            var record = Instantiate(_scoreRecordPrefab, _content);
            record.ScoreRecord = scoreRecord;
        }
    }

    // pontszámok betöltése a PlayerPrefsből (ha még nincs ilyen kulcs, akkor üres JSON tömbre inicializáljuk)
    private List<ScoreRecord> Scores => JsonConvert.DeserializeObject<List<ScoreRecord>>(PlayerPrefs.GetString("highScores", "[]"));
}