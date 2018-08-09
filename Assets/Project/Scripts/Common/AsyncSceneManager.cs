using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncSceneManager : MonoBehaviour {
    public static Task<bool> LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode) {
        var taskCompletionSource = new TaskCompletionSource<bool>();
        var sceneLoad = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
        sceneLoad.completed += operation => taskCompletionSource.SetResult(operation.isDone);
        return taskCompletionSource.Task;
    }
}
