using UnityEngine;
using UnityEngine.UI;

public class UIPoints : MonoBehaviour {
    private PlayerInventory _playerInventory;
    private Slider _slider;

    private void Awake() {
        _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        _slider = GetComponent<Slider>();
    }

    private void Update() {
        // minden updateben frissítjuk a pontszám kijelzőt a játékos pontszáma alapján
        _slider.value = _playerInventory.PickupCount;
    }
}
