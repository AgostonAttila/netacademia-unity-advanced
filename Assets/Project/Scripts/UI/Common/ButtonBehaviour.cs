﻿using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace WonderGame.UI.Common {
    public abstract class ButtonBehaviour<T> : MonoBehaviour where T : Object {
        [Inject] private Button _button;    // a Button komponens (ugyanarról a GameObjectről)
        protected T Controller;    // referencia a controllerre (T típusú, UnityGame.Object leszármazott)

        private void Awake() {
            Controller = FindObjectOfType<T>();
        }

        private void Start() {
            // a gomb kattintás eseményre feliratkozunk az absztrakt OnClick metódussal, a metódust majd a leszármazott osztály implementálja
            _button.onClick.AddListener(OnClick);
        }

        private void OnDestroy() {
            // leiratkozunk megsemmisüléskor, hibák elkerülésére
            _button.onClick.RemoveListener(OnClick);
        }

        // absztrakt kattintás eseménykezelő, a leszármazott osztálynak felül kell definiálnia
        protected abstract void OnClick();
    }
}
