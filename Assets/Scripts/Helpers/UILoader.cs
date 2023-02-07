using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    private void Start()
    {
        if (!SceneManager.GetSceneByName("UI").isLoaded)
        {
            SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        }
    }
}
