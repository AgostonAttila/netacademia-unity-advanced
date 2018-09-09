// SettingsUIController típusú controllerrel működő gomb (Controller referencián keresztül éri el)

using WonderGame.UI.Common;

namespace WonderGame.UI.Settings {
    public class SaveButton : ButtonBehaviour<SettingsUIController> {
        protected override void OnClick() {
            Controller.OnSaveClicked();
        }
    }
}