using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : GameUnit
{
    [SerializeField] private ColorData _colorData;
    [SerializeField] private Renderer _renderer;
    protected ColorType _colorType;
    
    public ColorType ColorType
    {
        get
        {
            return ColorType;
        }

        set
        {
            this.ColorType = value;
        }
    }

    public void ChangeColor(ColorType colorType)
    {
        this.ColorType = colorType;
        _renderer.material = _colorData.GetColorMat(ColorType);
    }

    public override void OnInit()
    {
        
    }
}
