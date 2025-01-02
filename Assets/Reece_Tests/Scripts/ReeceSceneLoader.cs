using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReeceSceneLoader : MonoBehaviour
{
    [SerializeField] public SceneAsset sceneToLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad.name);
    }
}
