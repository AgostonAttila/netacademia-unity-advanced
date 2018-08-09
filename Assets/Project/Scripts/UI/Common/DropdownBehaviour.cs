using UnityEngine;
using UnityEngine.UI;

public abstract class DropdownBehaviour<T> : MonoBehaviour where T : Object {
    protected Dropdown Dropdown;
    protected T Controller; // referencia a controllerre (T típusú, UnityGame.Object leszármazott)

    private void Awake() {
        Dropdown = GetComponent<Dropdown>();
        Controller = FindObjectOfType<T>();
    }

    protected virtual void Start() {
        Dropdown.onValueChanged.AddListener(OnValueChange);
    }

    private void OnDestroy() {
        Dropdown.onValueChanged.RemoveListener(OnValueChange);
    }

    protected abstract void OnValueChange(int value);
}