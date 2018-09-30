using UnityEngine;
using UnityEngine.Purchasing;
using WonderGame.UI.Common;

namespace WonderGame.UI.MainMenu {
    public class MainMenuController : MonoBehaviour {
        [SerializeField] private UIWindow _splashWindow;          // splash ablak
        [SerializeField] private UIWindow _mainMenuWindow;        // főmenü ablak

        private MainMenuState _mainMenuState = MainMenuState.Splash;    // kezdetben splash ablak
    
        private void Start() {
            _splashWindow.Show();    // splash ablak megjelenítése
        }

        private async void Update() {
            if (_mainMenuState == MainMenuState.Splash && Input.anyKeyDown) {    // bármelyik gomb megnyomására átváltunk a főmenü ablakra
                await _splashWindow.Hide();
                _mainMenuWindow.Show();
                _mainMenuState = MainMenuState.Menu;
            }
        }

        public void ExitGame() {
            Debug.Log("Exited game!");
            Application.Quit();    // kilépés a játékból
        }

        // callback hívás sikeres IAP vásárlás esetén
        public void OnBuy2TimesScore(Product product) {
            Debug.Log("Succesfully bought 2x score.");
            PlayerPrefs.SetInt("scoreMultiplier", 2);    // beállítjuk a kétszeres szorzót a játékosnak
        }
    }
}
