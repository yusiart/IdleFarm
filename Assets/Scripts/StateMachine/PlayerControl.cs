using System;
using UnityEngine;

public class PlayerControl : State
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private FloatingJoystick _floatingJoystick;

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Animator.SetBool("IsMow", false);
            Animator.SetBool("IsWalking", true);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            Animator.SetBool("IsWalking", false);
        }
    }

    private void Move()
    {
        Rigidbody.velocity = new Vector3(_floatingJoystick.Horizontal * _speed, Rigidbody.velocity.y,
            _floatingJoystick.Vertical * _speed);

        if (_floatingJoystick.Horizontal != 0 || _floatingJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(Rigidbody.velocity);
        }
    }
}
