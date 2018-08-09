using UnityEngine;

public class UIDialogResponseButton : ButtonBehaviour<UIDialog> {
    [SerializeField] private bool _selection;
    
    protected override void OnClick() {
        // meghívjuk a dialog OnSelection függvényét a megfelelő válasszal (true/false)
        Controller.OnSelection(_selection);
    }
}