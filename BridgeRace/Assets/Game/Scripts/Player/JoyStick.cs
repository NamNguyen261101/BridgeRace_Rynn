using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    // Direction
    public static Vector3 _direction;
    [SerializeField] private GameObject _joystick;
    [SerializeField] private RectTransform _background, _knob;
    [SerializeField] private float _knobRange;
    private Vector3 _startPosition, _currentPosition;
    private Vector3 _screen; // _screen game

    private Vector3 _mousePoisition => Input.mousePosition - _screen/2; // always separate screen view from any device

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = _mousePoisition;
            _joystick.SetActive(true);
            _background.anchoredPosition = _startPosition; 
            // depend on when player touch the screen then append the joystick
        }

        if (Input.GetMouseButton(0))
        {
            _currentPosition = _mousePoisition;
            // calculate position of knob
            _knob.anchoredPosition = Vector3.ClampMagnitude((_currentPosition - _startPosition), _knobRange) + _startPosition;
            Debug.Log("Test knob angle");

            _direction = (_currentPosition - _startPosition).normalized;
            _direction.z = _direction.y;
            _direction.y = 0;
        }





    }
}
