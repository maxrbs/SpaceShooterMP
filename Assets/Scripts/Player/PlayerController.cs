using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public string PlayerName;
    
    [SerializeField] private MoveComponent moveComponent;
    [SerializeField] private WeaponComponent weaponComponent;
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private CollectorComponent collectorComponent;

    [SerializeField] private PlayerTag playerTag;


    [SerializeField] private float spawnRange = 3f;

    public override void OnNetworkSpawn()
    {
        transform.position += new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), 0f);
        transform.Rotate(Vector3.forward, Random.Range(0f, 360f));

        playerTag.SetName(PlayerName);
    }

}
