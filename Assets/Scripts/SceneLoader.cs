using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private Animator splashScreenAnimator;
    private string nextSceneName;

    private void Awake()
    {
        splashScreenAnimator = GetComponent<Animator>();
        BrightenScreen();
    }

    public void LoadScene(string sceneName)
    {
        nextSceneName = sceneName;
        DarkenScreen();        
    }

    private void DarkenScreen()
    {
        splashScreenAnimator.Play("Show");
    }

    private void BrightenScreen()
    {
        splashScreenAnimator.Play("Hide");
    }

    private void StartLoadingScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void LoadExitGame()
    {
        Application.Quit();
    }
}
