using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PopUpObject : MonoBehaviour
{
    private Animator animatorComponent;
    private bool isActive;

    private void Start()
    {
        isActive = false;
        animatorComponent = GetComponent<Animator>();
    }

    public void ShowPopUp()
    {
        if (isActive) return;

        animatorComponent.Play("Show");
        isActive = true;
    }

    public void ClosePopUp(float delayInSeconds)
    {
        StartCoroutine(CloseWithDelay(delayInSeconds));
    }

    public void ClosePopUp()
    {
        if (!isActive) return;

        isActive = false;
        animatorComponent.Play("Close");
        StopAllCoroutines();
    }

    private IEnumerator CloseWithDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ClosePopUp();
    }

}
