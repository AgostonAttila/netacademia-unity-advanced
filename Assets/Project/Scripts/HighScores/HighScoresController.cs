using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

namespace WonderGame.HighScores {
    public class HighScoresController {
        // pontszámok betöltése a PlayerPrefsből (ha még nincs ilyen kulcs, akkor üres JSON tömbre inicializáljuk)
        public List<ScoreRecord> Scores => 
            JsonConvert.DeserializeObject<List<ScoreRecord>>(PlayerPrefs.GetString("highScores", "[]"));

        public void AddHighScore(string playerName, int score) {
            var newRecord = new ScoreRecord {Name = playerName, Score = score};
            var highScores = JsonConvert.DeserializeObject<List<ScoreRecord>>(PlayerPrefs.GetString("highScores", "[]"));
            highScores.Add(newRecord);
            highScores = highScores
                .OrderByDescending(r => r.Score)
                .ToList();

            PlayerPrefs.SetString("highScores", JsonConvert.SerializeObject(highScores));
        }
    }
}