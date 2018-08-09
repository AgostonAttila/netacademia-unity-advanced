public class VolumeSlider : SliderBehaviour<SettingsUIController> {
	// kezdeti érték beállítása
	protected override void Start() {
		Slider.value = Controller.GameSettings.Volume;
		base.Start();
	}

	// érték beállítása és beállítjuk, hogy módosult egy érték
	protected override void OnValueChange(float value) {
		Controller.GameSettings.Volume = value;
		Controller.IsSettingsDirty = true;
	}
}
