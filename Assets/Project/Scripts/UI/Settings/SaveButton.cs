// SettingsUIController típusú controllerrel működő gomb (Controller referencián keresztül éri el)
public class SaveButton : ButtonBehaviour<SettingsUIController> {
    protected override void OnClick() {
        Controller.OnSaveClicked();
    }
}