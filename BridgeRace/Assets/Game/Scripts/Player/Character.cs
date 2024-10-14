using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region Param 
    // Check Ground
    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask _layerMask;



    // Bricks
    [SerializeField] private GameObject _brickPrefabs;
    [SerializeField] private List<GameObject> _listBricks;
    [SerializeField] private Transform brickContainer;

    private float _brickHeight = 0.1f;
    #endregion 
    void Start()
    {
        _listBricks = new List<GameObject>();

    }

    public void OnInit()
    {
        ClearBrick();
    }
    void Update()
    {
        
    }

    private void AddBrick(GameObject newObject)
    {

    }

    private void RemoveBrick()
    {

    }

    private void ClearBrick()
    {

    }
}
