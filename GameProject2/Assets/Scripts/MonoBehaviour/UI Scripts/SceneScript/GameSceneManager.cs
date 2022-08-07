using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip click;
    public static void loadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
