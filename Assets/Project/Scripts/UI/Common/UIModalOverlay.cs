using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// dialógushoz háttérkép elsötétítése, háttérben lévő vezérlők elfedése
public class UIModalOverlay : MonoBehaviour {
    private Image _image;
    private float _shownAlpha;

    private void Awake() {
        _image = GetComponent<Image>();
    }

    // kezdetben alpha 0, és a raycastTarget off, hogy ne fedje el a vezérlőket
    private void Start() {
        _image.raycastTarget = false;
        _shownAlpha = _image.color.a;
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0);
    }

    // megjelenítés
    public void Show() {
        _image.raycastTarget = true;        // kattintások elkapása
        _image                              // megjelenítjük a képet
            .DOFade(_shownAlpha, 0.2f)
            .SetEase(Ease.InOutCubic);
    }

    // elrejtés
    public void Hide() {
        _image.raycastTarget = false;        // kattintások átengedése
        _image                               // elrejtjük a képet
            .DOFade(0, 0.2f)
            .SetEase(Ease.InOutCubic);
    }
}
