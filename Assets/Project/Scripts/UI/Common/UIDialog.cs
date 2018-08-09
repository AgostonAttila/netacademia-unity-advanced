public class UIDialog : UIWindow {
    public delegate void SelectionCallback(bool selection);

    public event SelectionCallback SelectionCallbackEvent;

    // ha a felhaszáló megnyomja az egyik gombot, akkor elrejtjük az ablakot és elsütjük az eseményt
    public void OnSelection(bool selection) {
        Hide();
        if (SelectionCallbackEvent != null) {
            SelectionCallbackEvent(selection);
        }
    }
}