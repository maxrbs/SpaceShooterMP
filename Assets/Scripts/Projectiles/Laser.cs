using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
//[RequireComponent(typeof(Rigidbody2D))]
public class Laser : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private float lifeTime;
    
    private Rigidbody2D rigidbodyComponent;

    private void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();

        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        //explosion.transform.parent = null;
        //Destroy(explosion, 10f);
        GameObject collisionedObject = collision.gameObject;
        print(collisionedObject.name);
        if (collisionedObject.TryGetComponent(out HealthComponent hpComponent))
        {
            hpComponent.ApplyDamage(damage);
        }

        Destroy(gameObject);
    }
}
