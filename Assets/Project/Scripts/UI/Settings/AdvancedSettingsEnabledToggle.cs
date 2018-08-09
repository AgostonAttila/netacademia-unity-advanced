public class AdvancedSettingsEnabledToggle : ToggleBehaviour<SettingsUIController> {
	// kezdeti érték beállítása
	protected override void Start() {
		Toggle.isOn = Controller.GameSettings.IsAdvancedGraphicsEnabled;
		base.Start();
	}
	
	// érték beállítása és beállítjuk, hogy módosult egy érték
	protected override void OnValueChange(bool value) {
		Controller.GameSettings.IsAdvancedGraphicsEnabled = value;
		Controller.IsSettingsDirty = true;
	}
}
