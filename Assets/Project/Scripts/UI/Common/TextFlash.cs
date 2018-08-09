using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// szöveg villogtatása
public class TextFlash : MonoBehaviour {
    [SerializeField] private float _flashDuration;    // villogás sebessége
    
    private Text _text;

    private void Awake() {
        _text = GetComponent<Text>();
    }

    private void Start() {
        _text
            .DOFade(0, _flashDuration)       // alpha értéket animáljuk (0 és 1 között, 1-ről indítva)
            .SetLoops(-1, LoopType.Yoyo);    // -1: végtelenítve, a Yoyo az odavissza végtelenítést határozza meg
    }
}
