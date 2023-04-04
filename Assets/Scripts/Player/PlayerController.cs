using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using Unity.Collections;

public class PlayerController : NetworkBehaviour
{
    private NetworkVariable<FixedString128Bytes> playerName = new NetworkVariable<FixedString128Bytes>(
            "Player0", NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);

    [SerializeField] private MoveComponent moveComponent;
    [SerializeField] private WeaponComponent weaponComponent;
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private CollectorComponent collectorComponent;

    [SerializeField] private PlayerTag playerTag;

    [SerializeField] private float spawnRange = 3f;

    public override void OnNetworkSpawn()
    {
        UpdatePlayerData();
        UpdatePositionServerRpc();
    }

    public void UpdatePlayerData()
    {
        playerName.Value = "Player" + (OwnerClientId + 1).ToString();
        playerTag.SetName(playerName.Value.ToString());
    }

    [ServerRpc(RequireOwnership = false)]
    public void UpdatePositionServerRpc()
    {
        transform.position += new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), 0f);
        transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
    }
}
