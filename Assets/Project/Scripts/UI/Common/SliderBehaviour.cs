using UnityEngine;
using UnityEngine.UI;

public abstract class SliderBehaviour<T> : MonoBehaviour where T : Object {
	protected Slider Slider;
	protected T Controller; // referencia a controllerre (T típusú, UnityGame.Object leszármazott)

	private void Awake() {
		Slider = GetComponent<Slider>();
		Controller = FindObjectOfType<T>();
	}

	protected virtual void Start() {
		Slider.onValueChanged.AddListener(OnValueChange);
	}

	private void OnDestroy() {
		Slider.onValueChanged.RemoveListener(OnValueChange);
	}

	protected abstract void OnValueChange(float value);
}