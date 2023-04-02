using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float pushForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float lifeTime;
    
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out HealthComponent hpComponent))
            hpComponent.ApplyDamage(damage);

        if (collision.gameObject.TryGetComponent(out Rigidbody2D rbComponent))
            rbComponent.AddForce(Vector3.up * pushForce, ForceMode2D.Impulse);

        PerformExplosion();
    }

    public void PerformExplosion()
    {
        //GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        //explosion.transform.parent = null;
        //Destroy(explosion, 10f);
        print("Boom");
        Destroy(gameObject);
    }
}
