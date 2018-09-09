using WonderGame.UI.Common;

namespace WonderGame.UI.Game {
    public class ContinueGameButton : ButtonBehaviour<GameUIController> {
        protected override void OnClick() {
            Controller.ContinueGame();
        }
    }
}
