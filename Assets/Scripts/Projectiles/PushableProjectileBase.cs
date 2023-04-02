using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PushableProjectileBase : ProjectileBase
{
    [SerializeField] private float pushForce;

    protected void PerformPush(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody2D rbComponent))
            rbComponent.AddForce(Vector3.up * pushForce, ForceMode2D.Impulse);
    }
}
