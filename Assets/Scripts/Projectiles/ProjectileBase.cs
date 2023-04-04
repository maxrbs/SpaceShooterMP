using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using Unity.Netcode;
using UnityEngine;

public abstract class ProjectileBase : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;
    private float startTime;

    public UnityEvent OnTouch;


    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        
        if (Time.time > startTime + lifeTime)
            DestroyObjectServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    public void DestroyObjectServerRpc()
    {
        GetComponent<NetworkObject>().Despawn();
        Destroy(gameObject, 0.05f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PerformTouch(collision);
    }

    protected abstract void PerformTouch(Collision2D collision);

}
