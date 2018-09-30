using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace WonderGame.HighScores {
    public class HighScoresController {
        public void AddHighScore(string playerName, int score) {
            var newRecord = new ScoreRecord {Name = playerName, Score = score};
            var highScores = JsonConvert.DeserializeObject<List<ScoreRecord>>(PlayerPrefs.GetString("highScores", "[]"));
            highScores.Add(newRecord);
            highScores = highScores
                .OrderByDescending(r => r.Score)
                .ToList();

            PlayerPrefs.SetString("highScores", JsonConvert.SerializeObject(highScores));
        }

        public async Task<List<ScoreRecord>> LoadScores() {
            // HTTP GET request
            var request = UnityWebRequest.Get("https://demo1255466.mockable.io/highscores");
            await request.SendWebRequest();

            // hibakezelés
            if (request.isNetworkError || request.isHttpError) {
                Debug.LogError(request.error);
                return null;
            }

            // a HTTP válasz szövegét feldolgozzuk
            var highScores = JsonConvert.DeserializeObject<List<ScoreRecord>>(request.downloadHandler.text)
                .OrderByDescending(r => r.Score)
                .ToList();

            return highScores;
        }
    }
}