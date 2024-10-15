using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    [SerializeField] private float speed = 5.0f;

    public override void OnInit()
    {
        base.OnInit();
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


}
