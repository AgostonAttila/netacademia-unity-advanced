public class AudioEnabledToggle : ToggleBehaviour<SettingsUIController> {
    // kezdeti érték beállítása
    protected override void Start() {
        Toggle.isOn = Controller.GameSettings.IsAudioEnabled;
        base.Start();
    }

    // érték beállítása és beállítjuk, hogy módosult egy érték
    protected override void OnValueChange(bool value) {
        Controller.GameSettings.IsAudioEnabled = value;
        Controller.IsSettingsDirty = true;
    }
}
