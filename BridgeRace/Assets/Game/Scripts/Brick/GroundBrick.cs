using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBrick : ColorObject
{
    private void Start()
    {
        OnInit();
    }
    public override void OnInit()
    {
        base.OnInit();
        ChangeColor(ObjectColor);
    }
}
