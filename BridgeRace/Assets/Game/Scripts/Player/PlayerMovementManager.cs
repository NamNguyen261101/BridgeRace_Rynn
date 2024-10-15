using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : Character
{
    [SerializeField] private VariableJoystick _joyStick;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Canvas _inputCanvas;
    public bool _isJoyStick;


    private void Start()
    {
        EnableJoyStickInput();
    }
    public void EnableJoyStickInput()
    {
        _isJoyStick = true;
        _inputCanvas.gameObject.SetActive(true);
    }


    private void Update()
    {
        if (_isJoyStick) 
        { 
            var moveDirection = new Vector3(_joyStick.Direction.x, 0f, _joyStick.Direction.y);

            // Vector3 nextPosition = TransformObject.position + _joyStick.Direction * Time.deltaTime * speed;
            // Vector3 nextPosition = TransformObject.position * (speed * Time.deltaTime * _joyStick.Direction);
            if (CanMove(moveDirection + Vector3.forward))
            {
                TransformObject.position = CheckGround(moveDirection);
                //ChangeAnim(AnimationState.run);
            }
            if ((Vector3) _joyStick.Direction != Vector3.zero)
            {
                TransformObject.forward = _joyStick.Direction;
            }
        }
    }
}
