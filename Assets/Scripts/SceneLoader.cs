using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    private Animator splashScreenAnimator;
    private string nextSceneName;

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

    private void Awake()
    {
        splashScreenAnimator = GetComponent<Animator>();
        BrightenScreen();
    }

    private void StartLoadingScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
