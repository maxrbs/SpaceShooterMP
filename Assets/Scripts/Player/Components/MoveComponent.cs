using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MoveComponent : MonoBehaviour
{
    public bool IsCanMove;
    
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float maxSpeed;

    private Rigidbody2D rigidbodyComponent;
    private Animator animatorComponent;
    private Joystick moveJoystick;


    private void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        animatorComponent = GetComponent<Animator>();
        moveJoystick = FindObjectOfType<MoveJoystick>();    // заменить на ченить более надежное

    }

    private void Update()
    {
        // if (!isOwner) return;

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
