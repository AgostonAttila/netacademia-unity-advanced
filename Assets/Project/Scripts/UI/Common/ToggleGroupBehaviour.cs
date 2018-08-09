using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class ToggleGroupBehaviour<T> : MonoBehaviour where T : Object {
    [SerializeField] protected Toggle[] Toggles;
    protected T Controller; // referencia a controllerre (T típusú, UnityGame.Object leszármazott)

    private Dictionary<Toggle, UnityAction<bool>> _listeners;
    
    private void Awake() {
        Controller = FindObjectOfType<T>();
    }

    protected virtual void Start() {
        _listeners = new Dictionary<Toggle, UnityAction<bool>>();
        for (var i = 0; i < Toggles.Length; i++) {
            var toggle = Toggles[i];
            var index = i;    // látszólag értelmetlen, bizonyos platformokon viszont bugokat okoz, ha lambda kifejezésben közvetlenül használjuk az akutális indexet
            UnityAction<bool> listener = value => OnValueChanged(index, value);    // listener függvény, ami továbbhív az indexszel együtt
            
            toggle.onValueChanged.AddListener(listener);
            _listeners.Add(toggle, listener);    // elmentjük a listenert, hogy később leiratkozhassunk róla
        }
    }

    private void OnDestroy() {
        // leiratkozás a listenerekről
        foreach (var keyValuePair in _listeners) {
            keyValuePair.Key.onValueChanged.RemoveListener(keyValuePair.Value);
        }
    }

    protected abstract void OnValueChanged(int index, bool value);
}