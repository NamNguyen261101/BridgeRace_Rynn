using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : Character
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private Rigidbody _rigi;

    private Vector3 _moveVector;

    private void Start()
    {
       
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveVector = Vector3.zero;
        _moveVector.x = _joystick.Horizontal * _moveSpeed * Time.deltaTime;
        _moveVector.y = 0;
        _moveVector.z = _joystick.Vertical * _moveSpeed * Time.deltaTime;

       

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _rotateSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);

            // animation
            //run
        } 
        else if (_joystick.Horizontal == 0 || _joystick.Vertical == 0)
        {
            // idle
        }
        if (CanMove(_moveVector))
        {
            _rigi.MovePosition(_rigi.position + CheckGround(_moveVector));
        }
       
    }
}
