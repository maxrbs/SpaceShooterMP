using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using Unity.Netcode;
using UnityEngine;

public abstract class ProjectileBase : NetworkBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float safeZoneRadius;

    private float startTime;
    private Vector2 startPosition;

    public UnityEvent OnTouch;


    private void Start()
    {
        startTime = Time.time;
        startPosition = transform.position;

        if (!GetComponent<NetworkObject>())
            gameObject.AddComponent<NetworkObject>();
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
        if (Vector2.Distance(transform.position, startPosition) < safeZoneRadius)
            return;

        PerformTouch(collision);
    }

    protected abstract void PerformTouch(Collision2D collision);

}
