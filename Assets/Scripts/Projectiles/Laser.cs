using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : ProjectileBase
{
    [SerializeField] private float damage;
    [SerializeField] private GameObject explosionEffect;

    public void PerformExplosion()
    {
        //GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        //explosion.transform.parent = null;
        //Destroy(explosion, 10f);
        print("Boom");
        
    }

    protected override void PerformTouch(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out HealthComponent hpComponent))
            hpComponent.ApplyDamage(damage);
        else
            print("no");

        PerformExplosion();
        
        Destroy(gameObject);
    }
}
