using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveComponent : NetworkBehaviour
{
    public bool IsCanMove;
    
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float maxSpeed;

    private Rigidbody2D rigidbodyComponent;
    private Joystick moveJoystick;


    private void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        moveJoystick = FindObjectOfType<MoveJoystick>();

    }

    private void Update()
    {
        if (!IsOwner) return;

        if (!IsCanMove) return;

        if (moveJoystick.Direction.sqrMagnitude > moveJoystick.DeadZone * moveJoystick.DeadZone)
        {
            Vector2 direction = moveJoystick.Direction;

            rigidbodyComponent.velocity = Vector2.ClampMagnitude(rigidbodyComponent.velocity + direction * acceleration * Time.deltaTime, maxSpeed);

        }
        else
        {
            rigidbodyComponent.velocity = Vector2.Lerp(rigidbodyComponent.velocity, Vector2.zero, deceleration * Time.deltaTime); 
        }
    }

}
