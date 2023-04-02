using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string PlayerName;
    
    [SerializeField] private MoveComponent moveComponent;
    [SerializeField] private WeaponComponent weaponComponent;
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private CollectorComponent collectorComponent;

    [SerializeField] private PlayerTag playerTag;

    private void Start()
    {
        // пока так, потом на OnSpawn
        playerTag.SetName(PlayerName);
    }

}
