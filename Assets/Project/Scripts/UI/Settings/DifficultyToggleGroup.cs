public class DifficultyToggleGroup : ToggleGroupBehaviour<SettingsUIController> {
    // kezdeti érték beállítása
    protected override void Start() {
        // a Difficulty értéknek megfelelő Toggle bekapcsolása kezdetben
        for (var i = 0; i < Toggles.Length; i++) {
            if (Controller.GameSettings.Difficulty == i) {
                Toggles[i].isOn = true;
            }
        }

        base.Start();
    }

    // érték beállítása és beállítjuk, hogy módosult egy érték
    protected override void OnValueChanged(int index, bool value) {
        if (value) {
            Controller.GameSettings.Difficulty = index;
            Controller.IsSettingsDirty = true;
        }
    }
}