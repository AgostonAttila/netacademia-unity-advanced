using UnityEngine;
using UnityEngine.Analytics;

namespace WonderGame.UI.Game {
    public class GameAnalytics : MonoBehaviour {
        private void Start() {
            AnalyticsEvent.GameStart();    // game_start eseményt küldünk a játék indításakor
        }
    }
}