using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : GameUnit 
{
    [SerializeField] private ColorData _colorData;
    [SerializeField] private Renderer _renderer;
    [SerializeField] protected ColorType _colorType;
    
    public ColorType ObjectColor
    {
        get
        {
            return _colorType;
        }

        set
        {
            this._colorType = value;
        }
    }

    public void ChangeColor(ColorType colorType)
    {
        this.ObjectColor = colorType;
        _renderer.material = _colorData.GetColorMat(ObjectColor);
    }

    public override void OnInit()
    {
        
    }
}
