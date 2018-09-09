using WonderGame.UI.Common;

namespace WonderGame.UI.Settings {
    public class CancelButton : ButtonBehaviour<SettingsUIController> {
        protected override void OnClick() {
            Controller.OnCancelClicked();
        }
    }
}
