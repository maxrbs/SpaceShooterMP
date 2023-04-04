using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using Unity.Netcode;
using UnityEngine;

public class WeaponComponent : NetworkBehaviour
{
    public bool IsCanAim;

    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private float shotsDelay;
    [SerializeField] private Transform ammoSpawnPointsContainer;

    public UnityEvent OnShoot;

    private Joystick aimJoystick;
    private int nextSpawnPointIndex;
    private float lastShotTime;

    private void Start()
    {
        aimJoystick = FindObjectOfType<AimJoystick>();
        nextSpawnPointIndex = 0;
    }

    private void Update()
    {
        if (!IsOwner) return;

        if (!IsCanAim) return;         

        if (aimJoystick.Direction.sqrMagnitude > aimJoystick.DeadZone * aimJoystick.DeadZone)
        {
            Vector2 direction = aimJoystick.Direction;

            float rotationZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, rotationZ), 0.3f);

            if (direction.magnitude > 0.85f)
                TryShoot();
        }

    }

    public void TryShoot()
    {
        if (lastShotTime + shotsDelay < Time.time)
            Shoot();
    }

    private void Shoot()
    {
        SpawnBulletServerRpc();

        UpdateNextSpawnPointServerRpc();

        lastShotTime = Time.time;

        OnShoot.Invoke();
    }

    [ServerRpc(RequireOwnership = false)]
    private void SpawnBulletServerRpc()
    { 
        Transform spawnTransform = ammoSpawnPointsContainer.GetChild(nextSpawnPointIndex);
        GameObject bullet = Instantiate(ammoPrefab, spawnTransform.position, spawnTransform.rotation);

        bullet.GetComponent<NetworkObject>().Spawn();
    }

    [ServerRpc(RequireOwnership = false)]
    private void UpdateNextSpawnPointServerRpc()
    {
        nextSpawnPointIndex++;
        if (nextSpawnPointIndex >= ammoSpawnPointsContainer.childCount)
            nextSpawnPointIndex = 0;
    }
}
