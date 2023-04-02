using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class CollectableBase : MonoBehaviour
{
    [SerializeField] private GameObject collectEffect;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryCollect(collision.gameObject);

        PerformCollectEffect();
        Destroy(gameObject);
    }

    protected abstract void TryCollect(GameObject collidedObject);

    private void PerformCollectEffect()
    {
        //GameObject effect = Instantiate(collectEffect, transform.position, Quaternion.identity);
        //effect.transform.parent = null;

        //Destroy(effect, 5f);
    }
}
