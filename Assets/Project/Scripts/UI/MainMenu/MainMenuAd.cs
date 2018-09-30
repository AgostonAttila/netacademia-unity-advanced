using UnityEngine.Advertisements;
using UnityEngine;

namespace WonderGame.UI.MainMenu {
    public class MainMenuAd : MonoBehaviour {
        private void Start() {
            // ha van rendelkezésre álló "video" típusú hirdetés, akkor megjelenítjük
            if (Advertisement.IsReady("video")) {
                Advertisement.Show("video");
            }
        }
    }
}