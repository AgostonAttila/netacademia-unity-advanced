using UnityEngine;

public class GameUIController : MonoBehaviour {
    [SerializeField] private UIWindow _window;

    public void ContinueGame() {
        _window.Hide();
    }

    private void Update() {
        // escape gomb megnyomására ki-/bekapcsoljuk a menüt
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (_window.IsShown) _window.Hide();
            else _window.Show();
        }
    }
}
