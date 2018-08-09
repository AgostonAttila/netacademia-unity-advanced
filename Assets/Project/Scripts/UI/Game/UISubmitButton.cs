using UnityEngine;

public class UISubmitButton : SceneNavigationButton {
    [SerializeField] private EnterNameUIWindow _window;
    
    // mielőtt scene-t váltunk, elmentjük a pontszámot
    protected override void OnClick() {
        _window.OnSubmitClick();
        base.OnClick();
    }
}
