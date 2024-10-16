using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private float speed = 5.0f;

    private void Start()
    {
        OnInit();
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangeColor(ObjectColor);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 nextPosition = TransformObject.position + JoyStick._direction * Time.deltaTime * speed;
            if (CanMove(nextPosition + Vector3.forward))
            {
                TransformObject.position = CheckGround(nextPosition);
                //ChangeAnim(AnimationState.run);
            }
            if (JoyStick._direction != Vector3.zero)
            {
                TransformObject.forward = JoyStick._direction;
            }
        }
        /* if (Input.GetMouseButtonUp(0))
         {
             ChangeAnim(AnimationState.idle);
         }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONSTANT.BRICK_GROUND))
        {
            ColorType brickColor = collision.GetComponent<GroundBrick>().ObjectColor;
            if (ObjectColor == brickColor)
            {
                // do something
                // AddBrick();
            }
        }
    }



}
