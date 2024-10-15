using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{
    #region Param 
    // animation
    [SerializeField] private Animator _anim;
    private AnimationState _animState;

    // Check Ground
    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask _groundLayerMask, _stairlayerMask;
    private RaycastHit _hit;

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

    public override void OnInit()
    {
        ClearBrick();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="nextPoint"></param>
    /// <returns></returns>
    public Vector3 CheckGround(Vector3 nextPoint)
    {
        
        Debug.DrawRay(nextPoint + Vector3.up, Vector3.down * 2f, Color.red, 1f);
        if (Physics.Raycast(nextPoint, Vector3.down, out _hit, 2f, _groundLayerMask))
        {
            return _hit.point + Vector3.up * 0.1f;
        }

        return TransformObject.position; // return to the point of object when touches it
    }

    public bool CanMove(Vector3 nextPosition) 
    {
        if (Physics.Raycast(nextPosition + Vector3.up, Vector3.down, out _hit, 2f, _stairlayerMask))
        {

        }

        return true;
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



    public enum AnimationState
    {
        IDLE,
        RUN,
        DANCE
    }
}
