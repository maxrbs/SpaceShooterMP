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
    

    private void Update()
    {
        
    }
}
