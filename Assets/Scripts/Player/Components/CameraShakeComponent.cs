using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeComponent : MonoBehaviour
{
    private Animator camAnimator;

    private void Start()
    {
        camAnimator = Camera.main.gameObject.GetComponent<Animator>();
    }

    public void ShakeByCollect()
    {
        camAnimator.Play("ShakeByCollect");
    }

    public void ShakeByShot()
    {
        camAnimator.Play("ShakeByShot");
    }
    public void ShakeByDamage()
    {
        camAnimator.Play("ShakeByDamage");
    }
}
