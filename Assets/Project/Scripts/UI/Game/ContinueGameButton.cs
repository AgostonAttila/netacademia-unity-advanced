public class ContinueGameButton : ButtonBehaviour<GameUIController> {
    protected override void OnClick() {
        Controller.ContinueGame();
    }
}
