using Zenject;
#pragma warning disable 649

namespace WonderGame.HighScores {
    public class HighScoresInstaller : MonoInstaller<HighScoresInstaller> {
        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<HighScoresController>().AsSingle();    // Singleton osztály
        }
    }
}