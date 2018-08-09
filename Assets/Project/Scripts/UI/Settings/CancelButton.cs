public class CancelButton : ButtonBehaviour<SettingsUIController> {
    protected override void OnClick() {
        Controller.OnCancelClicked();
    }
}
