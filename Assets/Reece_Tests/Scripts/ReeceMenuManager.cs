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
        SceneManager.LoadScene(2);
    }

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Settings()
    {
        SceneManager.LoadScene(3);
    }

    public void Intro()
    {
        SceneManager.LoadScene(0);
    }

    public void creddits()
    {
        SceneManager.LoadScene(4);
    }
}
