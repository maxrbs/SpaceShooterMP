using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MoveComponent : MonoBehaviour
{
    public bool IsCanMove;
    
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigidbodyComponent;
    private Animator animatorComponent;
    private Joystick moveJoystick;


    private void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        animatorComponent = GetComponent<Animator>();
        moveJoystick = FindObjectsOfType<Joystick>()[1];    // заменить на ченить более надежное

    }

    private void Update()
    {
        // if (!isOwner) return;

        if (!IsCanMove) return;

        if (moveJoystick.Direction.sqrMagnitude > moveJoystick.DeadZone * moveJoystick.DeadZone)
        {
            Vector2 direction = moveJoystick.Direction;
            
            //Vector3 velocity = rigidbodyComponent.velocity;
            //velocity.x += direction.x * moveSpeed * Time.deltaTime;
            //velocity.y += direction.y * moveSpeed * Time.deltaTime;

            //rigidbodyComponent.velocity = velocity;
            rigidbodyComponent.velocity += direction * moveSpeed * Time.deltaTime;

            //animatorComponent.SetFloat("Speed", direction.magnitude);

        }
    }


}
