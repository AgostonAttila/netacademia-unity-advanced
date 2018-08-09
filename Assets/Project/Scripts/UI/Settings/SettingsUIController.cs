using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsUIController : MonoBehaviour {
    [SerializeField] private UIModalOverlay _modalOverlay;        // sötét háttér modal dialoghoz
    [SerializeField] private UIDialog _confirmSettingsCancelDialogPrefab;    // felúgró ablak prefab
    [SerializeField] private UIWindow _window;    // referencia a UI Windowra

    public bool IsSettingsDirty { get; set; }        // true, ha valamelyik érték módosult a GameSettingsben
    public GameSettings GameSettings { get; set; }   // a játék beállításai
    
    private GameSettingsManager _gameSettingsManager;

    private void Awake() {
        _gameSettingsManager = FindObjectOfType<GameSettingsManager>();
    }

    private void Start() {
        IsSettingsDirty = false;
        GameSettings = _gameSettingsManager.GameSettings;
    }

    // Save gomb eseménykezelő
    public void OnSaveClicked() {
        _gameSettingsManager.GameSettings = GameSettings;
        SceneManager.LoadSceneAsync("Main Menu");
    }

    // Cancel gomb eseménykezelő
    public void OnCancelClicked() {
        if (IsSettingsDirty) {
            _modalOverlay.Show();    // sötét háttér megjelenítése

            // dialog ablak létrehozása, feliratkozás a felhasználói válasz eseményére
            var dialog = Instantiate(_confirmSettingsCancelDialogPrefab, transform);
            dialog.SelectionCallbackEvent += OnCancelConfirmSelection;
            dialog.Show();   
        } else {
            SceneManager.LoadSceneAsync("Main Menu");
        }
    }

    // callback függvény, amikor a felhasználó megnyomja az ok/cancel gombot a dialógus ablakban
    private async void OnCancelConfirmSelection(bool selection) {
        Debug.Log($"Dialog response: {selection}");
        _modalOverlay.Hide();    // sötét háttér elrejtése

        // ha az ok-ra nyomott, elrejtjük az ablakot, és bezárjuk a settings képernyőt
        if (selection) {
            await _window.Hide();
            SceneManager.UnloadSceneAsync("Settings");
        }
    }
}
