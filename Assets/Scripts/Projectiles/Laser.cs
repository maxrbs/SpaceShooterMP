using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : PushableProjectileBase
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

    protected override void PerformTouch(Collision collision)
    {
        PerformPush(collision);

        if (collision.gameObject.TryGetComponent(out HealthComponent hpComponent))
            hpComponent.ApplyDamage(damage);

        PerformExplosion();
        
        Destroy(gameObject);
    }
}
