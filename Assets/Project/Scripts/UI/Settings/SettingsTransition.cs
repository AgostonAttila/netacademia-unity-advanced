using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsTransition : MonoBehaviour {
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private float _tweenDurationSeconds;
    [SerializeField] private UIWindow _window;

    private void Start() {
        _backgroundImage.fillAmount = 0;    // kezdetben fill 0

        _backgroundImage
            .DOFillAmount(1, _tweenDurationSeconds)    // fill 1-re animálása _tweenDurationSeconds másodperc alatt
            .SetEase(Ease.InOutCubic)                // lassabban indul és lassabban fejeződik be az animáció
            .OnComplete(_window.Show);                // az animáció után meghívjuk a _window.Show() metódust
    }
}
