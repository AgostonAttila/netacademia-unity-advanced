using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour {
    private Slider _slider;
    private Text _text;

    private void Awake() {
        _slider = GetComponentInParent<Slider>();
        _text = GetComponent<Text>();
    }

    private void Update() {
        // a slider értékének megfelelően frissítjük a szöveget
        _text.text = $"{_slider.value} / {_slider.maxValue}";
    }
}
