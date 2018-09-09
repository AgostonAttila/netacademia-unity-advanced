using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using WonderGame.UI.Common;
using Zenject;
#pragma warning disable 649

namespace WonderGame.HighScores {
    [UsedImplicitly]
    public class HighScoresUIController : IInitializable {
        [Inject] private readonly UIScoreRecord.Factory _scoreRecordFactory;
        [Inject(Id = "Content")] private readonly Transform _content;
        [Inject] private readonly UIWindow _window;
        [Inject] private readonly HighScoresController _highScoresController;

        // megjelenítjuk az ablakot, betöltjük és megjelenítjük a pontszámokat
        public void Initialize() {
            _window.Show();
            ShowScores(_highScoresController.Scores);
        }

        // pontszámok megjelenítése (1 prefab példány 1 pontszámot jelenít meg)
        private void ShowScores(IEnumerable<ScoreRecord> scores) {
            foreach (var scoreRecord in scores) {
                _scoreRecordFactory.Create(_content, scoreRecord);
            }
        }
    }
}