using UnityEngine;
using Zenject;

#pragma warning disable 649

namespace WonderGame.HighScores {
    public class HighScoresUIInstaller : MonoInstaller<HighScoresUIInstaller> {
        [Inject] private HighScoresSettings _highScoresSettings;
        
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<HighScoresUIController>().AsSingle();    // Singleton osztály
            
            // UIScoreRecord objektumot a UIScoreRecord.Factory osztállyal példányosíthatunk
            // A Create() metódusnak 2 paramétere egy Transform és egy ScoreRecord objektum legyen
            // A megadott prefabot példányosítsa a híváskor, onnan "származzon" a UIScoreRecord komponens
            Container.BindFactory<Transform, ScoreRecord, UIScoreRecord, UIScoreRecord.Factory>()
                .FromComponentInNewPrefab(_highScoresSettings.UIScoreRecordPrefab);
        }
    }
}