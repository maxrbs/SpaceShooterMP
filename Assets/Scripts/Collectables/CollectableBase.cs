using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class CollectableBase : MonoBehaviour
{
    public UnityEvent OnCollect;

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        TryCollect(collision.gameObject);

        OnCollect.Invoke();
    }

    protected abstract void TryCollect(GameObject collidedObject);

}
