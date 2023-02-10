using PlasticGui.WorkspaceWindow.BranchExplorer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string scene = "UI";

    private void Start()
    {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            Scene sceneToLoad = SceneManager.GetSceneByName(scene);
            if(sceneToLoad == null) {
                Debug.LogError($"Couldn't find a scene with the name '{scene}'!");
                return;
            }
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            //asyncOperation.allowSceneActivation = false;
        }
    }
}
