using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    public string SceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void load()
    {
        SceneManager.LoadScene(SceneName);
    }
}
