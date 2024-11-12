using UnityEngine;
using UnityEngine.SceneManagement;

public class ReeceMenuManager : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayButtonAudio()
    {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
