using UnityEngine;
using WonderGame.HighScores;
using Zenject;

namespace WonderGame.Common.Settings {
    // Editorban szerkeszthető beállítások, project contextbe betöltve
    [CreateAssetMenu(fileName = "App Settings", menuName = "WonderGame/App Settings")]
    public class AppSettings : ScriptableObjectInstaller<AppSettings> {
        public HighScoresSettings HighScoresSettings;
        
        public override void InstallBindings() {
            Container.BindInstance(HighScoresSettings);
        }
    }
}