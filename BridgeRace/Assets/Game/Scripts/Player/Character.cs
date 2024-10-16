using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;

using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

public class Character : ColorObject
{
    #region Param 
    // animation
    [SerializeField] private Animator _anim;
    private AnimationState _animState;

    // Check Ground
    [SerializeField] private LayerMask _groundLayerMask, _stairlayerMask;
    private RaycastHit _hit;

    // Bricks
    [SerializeField] private GameObject _brickPrefabs;
    [SerializeField] private List<GameObject> _listBricks;
    [SerializeField] private Transform brickContainer;
    private float _brickHeight = 0.1f;

    // Color Object - Depend for character and 
    

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
    /// Check Ground for player - nguoi choi dung o tren ground thi moi dc di chuyen
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
    /// <summary>
    /// Verson 2: CheckGround when touche the plane - kiem tra player neu cham dat thi ms cho di chuyen
    /// </summary>
    /// <param name="nextPoint"></param>
    /// <returns></returns>
    public Vector3 CheckGrounded(Vector3 nextPoint) 
    {
        if (Physics.Raycast(nextPoint, Vector3.down, out _hit, 2f, _groundLayerMask))
        {
            Debug.DrawRay(nextPoint + Vector3.up, Vector3.down * 2f, Color.red, 1f);
            return _hit.point + Vector3.up * 0.1f;
        }
        return nextPoint;
    }

    /// <summary>
    /// Can Move to the stair and remove brick from player - nguoi choi di len cau va trai gach ra o duoi
    /// </summary>
    /// <param name="nextPosition"></param>
    /// <returns></returns>
    public bool CanMove(Vector3 nextPosition) 
    {
        if (Physics.Raycast(nextPosition + Vector3.up, Vector3.down, out _hit, 2f, _stairlayerMask))
        {
           /* if (nextPosition.z - TransformObject.position.z < 1)
            {
                return true;
            }*/

            if (nextPosition.z < 1)
            {
                return true;
            }
            /*else
            {
                if (hit.collider.GetComponent<ColorObject>().ColorType == ColorType)
                {
                    return true;
                }
                else
                {
                    if (brickList.Count > 0)
                    {
                        RemoveBrick();
                        hit.collider.GetComponent<ColorObject>().ChangeColor(ColorType);

                        // Respawn a new Birck in current Stage
                        stage.SpawnNewBrick(colorType);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }*/
        }

        return true;
    }

    
    /// <summary>
    /// Add brick
    /// </summary>
    /// <param name="newObject"></param>
    private void AddBrick()
    {
        // Object pooling
        // Sinh ra ben canh
       GameObject newBrick = BrickPooling.Instance.GetBrick();
        // newBrick.ChangeColor(ObjectColor);


    }

    /// <summary>
    /// Remove brick 
    /// </summary>
    private void RemoveBrick()
    {
        // List
        // TOdo
        // Xoa phan tu do di
    }

    private void ClearBrick()
    {
        // Clear All

    }





    public enum AnimationState
    {
        IDLE,
        RUN,
        DANCE
    }
}
