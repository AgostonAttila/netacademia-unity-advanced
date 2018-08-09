using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class UIWindow : MonoBehaviour {
    [SerializeField] private float _tweenDurationSeconds;

    private void Start() {
        transform.localScale = Vector3.zero;    // kezdetben scale 0
    }

    public virtual void Show() {
        transform
            .DOScale(1, _tweenDurationSeconds)    // scale-t 1-re animáljuk _tweenDurationSeconds másodperc alatt
            .SetEase(Ease.OutBounce);            // animáció legyen "pattogós"
    }

    // a TaskCompletionSource Taskját visszaadva "awaitelhető" lesz a függvényünk
    // az awaitelt hívás akkor tér vissza, amikor a TaskCompletionSource SetResult() metódusát meghívjuk
    // a generikus paraméter az így meghívott függvény visszatérési értékét definiálja
    public Task Hide() {
        var taskCompletionSource = new TaskCompletionSource<bool>();
        transform
            .DOScale(0, _tweenDurationSeconds)
            .SetEase(Ease.InOutCubic)
            .OnComplete(() => taskCompletionSource.SetResult(true));

        return taskCompletionSource.Task;
    }
    
    // igaz, ha a scale (0, 0, 0)
    public bool IsShown => transform.localScale != Vector3.zero;
}
