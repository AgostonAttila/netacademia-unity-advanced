using UnityEngine;

public class QualitySettingsSlider : SliderBehaviour<SettingsUIController> {
    // kezdeti érték beállítása
    protected override void Start() {
        Slider.value = Controller.GameSettings.GraphicsQuality;
        base.Start();
    }

    // érték beállítása és beállítjuk, hogy módosult egy érték
    protected override void OnValueChange(float value) {
        Controller.GameSettings.GraphicsQuality = Mathf.RoundToInt(value);
        Controller.IsSettingsDirty = true;
    }
}
