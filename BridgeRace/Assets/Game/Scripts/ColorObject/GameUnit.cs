using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameUnit : MonoBehaviour
{
    private Transform _transformObject;

    public Transform TransformObject
    {
        get
        {
            if (_transformObject == null)
            {
                _transformObject = transform;
            }

            return _transformObject;
        }
    }

    public abstract void OnInit();
}
