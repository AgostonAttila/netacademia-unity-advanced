using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneNavigationButton : MonoBehaviour {
    [SerializeField] private LoadSceneMode _loadSceneMode;
    [SerializeField] private string _loadingSceneName;
    [SerializeField] private string _targetSceneName;
    
    private Button _button;    // a Button komponens (ugyanarról a GameObjectről)

    private void Awake() {
        _button = GetComponent<Button>();
    }

    private void Start() {
        // a gomb kattintás eseményre feliratkozunk az absztrakt OnClick metódussal, a metódust majd a leszármazott osztály implementálja
        _button.onClick.AddListener(OnClick);
    }

    private void OnDestroy() {
        // leiratkozunk megsemmisüléskor, hibák elkerülésére
        _button.onClick.RemoveListener(OnClick);
    }

    protected virtual async void OnClick() {
        if (_loadSceneMode == LoadSceneMode.Additive && !string.IsNullOrEmpty(_loadingSceneName)) {
            // megvárjuk, amig a loading scene betöltődik
            await AsyncSceneManager.LoadSceneAsync(_loadingSceneName, LoadSceneMode.Additive);
        }
        
        // elkezdjük betölteni a cél scene-t
        var sceneLoad = SceneManager.LoadSceneAsync(_targetSceneName, _loadSceneMode);

        if (_loadSceneMode == LoadSceneMode.Additive && !string.IsNullOrEmpty(_loadingSceneName)) {
            // amikor betöltődött a cél jelenet, eltávolítjuk a mostani és a loading scene-t
            sceneLoad.completed += operation => {
                SceneManager.UnloadSceneAsync(_loadingSceneName);
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
            };
        }
    }
}
