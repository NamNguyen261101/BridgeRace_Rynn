using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPooling : Singleton<BrickPooling>
{
    [SerializeField] private GameObject _brickPrefab;
    [SerializeField] private Transform _brickContainer;

    public GameObject GetBrick()
    {
        return Instantiate(_brickPrefab, _brickContainer);
    }
}
