using UnityEngine;

public class AntiAliasingSlider : SliderBehaviour<SettingsUIController> {
    // kezdeti érték beállítása
    protected override void Start() {
        Slider.value = Controller.GameSettings.AntiAliasingLevel;
        base.Start();
    }

    // kikapcsolva, ha az advanced settings nincs bepipálva
    private void Update() {
        Slider.interactable = Controller.GameSettings.IsAdvancedGraphicsEnabled;
    }
    
    // érték beállítása és beállítjuk, hogy módosult egy érték
    protected override void OnValueChange(float value) {
        Controller.GameSettings.AntiAliasingLevel = Mathf.RoundToInt(value);
        Controller.IsSettingsDirty = true;
    }
}
