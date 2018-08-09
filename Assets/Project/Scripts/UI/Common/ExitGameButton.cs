using UnityEngine;
using UnityEngine.UI;

public class ExitGameButton : MonoBehaviour {
    private Button _button;

    private void Awake() {
        _button = GetComponent<Button>();
    }

    private void Start() {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy() {
        _button.onClick.RemoveListener(OnClick);
    }

    // gombra kattintáskor kilépünk a játékból
    private static void OnClick() {
        Application.Quit();
    }
}