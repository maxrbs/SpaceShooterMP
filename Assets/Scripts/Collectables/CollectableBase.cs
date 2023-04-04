using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class CollectableBase : NetworkBehaviour
{
    public UnityEvent OnCollect;

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        TryCollect(collision.gameObject);

        OnCollect.Invoke();
    }

    [ServerRpc(RequireOwnership = false)]
    public void DestroyObjectServerRpc()
    {
        GetComponent<NetworkObject>().Despawn();
        Destroy(gameObject, 0.05f);
    }

    protected abstract void TryCollect(GameObject collidedObject);

}
