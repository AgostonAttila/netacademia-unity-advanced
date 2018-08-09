public class LanguageDropdown : DropdownBehaviour<SettingsUIController> {
    // kezdeti érték beállítása
    protected override void Start() {
        Dropdown.value = Controller.GameSettings.Language;
        base.Start();
    }

    // érték beállítása és beállítjuk, hogy módosult egy érték
    protected override void OnValueChange(int value) {
        Controller.GameSettings.Language = value;
        Controller.IsSettingsDirty = true;
    }
}
