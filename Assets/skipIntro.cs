using UnityEngine;
using UnityEngine.SceneManagement;

public class skipIntro : MonoBehaviour
{
public string sceneName;
    void OnSkip()
    {
        SceneManager.LoadScene(sceneName);
    }

    
}
