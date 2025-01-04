using UnityEngine;
using UnityEngine.SceneManagement;

public class skipIntro : MonoBehaviour
{

    void OnSkip()
    {
        SceneManager.LoadScene(1);
    }
}
