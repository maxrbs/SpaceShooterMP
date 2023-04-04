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
        camAnimator.Play("ShakeOnCollect");
    }

    public void ShakeByShot()
    {
        camAnimator.Play("ShakeOnShot");
    }
    public void ShakeByDamage()
    {
        camAnimator.Play("ShakeOnDamage");
    }
}
