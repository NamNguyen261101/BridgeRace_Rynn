using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorData", menuName = "ColorData")]
public class ColorData : ScriptableObject
{
    [SerializeField] private Material[] colorMats;

    public Material GetColorMat(ColorType colorType)
    {
        return colorMats[(int)colorType];
    }

}

public enum ColorType
{
    Red = 0,
    Blue = 1,
    Green = 2,
    Pink = 3,
    Yellow = 4,
    Black = 5
}
