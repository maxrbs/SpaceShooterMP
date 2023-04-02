using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public abstract class PushableProjectileBase : ProjectileBase
{
    [SerializeField] private float pushForce;

    public UnityEvent OnPush;

    protected void PerformPush(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody2D rbComponent))
            rbComponent.AddForce(Vector3.up * pushForce, ForceMode2D.Impulse);

        OnPush.Invoke();
    }
}
