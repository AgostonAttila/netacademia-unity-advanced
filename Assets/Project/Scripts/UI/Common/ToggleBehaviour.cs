using UnityEngine;
using UnityEngine.UI;

public abstract class ToggleBehaviour<T> : MonoBehaviour where T : Object {
    protected Toggle Toggle;
    protected T Controller; // referencia a controllerre (T típusú, UnityGame.Object leszármazott)

    private void Awake() {
        Toggle = GetComponent<Toggle>();
        Controller = FindObjectOfType<T>();
    }

    protected virtual void Start() {
        Toggle.onValueChanged.AddListener(OnValueChange);
    }

    private void OnDestroy() {
        Toggle.onValueChanged.RemoveListener(OnValueChange);
    }

    protected abstract void OnValueChange(bool value);
}