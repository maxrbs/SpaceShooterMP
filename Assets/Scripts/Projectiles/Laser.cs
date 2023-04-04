using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : ProjectileBase
{
    [SerializeField] private float damage;

    protected override void PerformTouch(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out HealthComponent hpComponent))
            hpComponent.ApplyDamage(damage);

        OnTouch.Invoke();

        DestroyObjectServerRpc();
    }
}
