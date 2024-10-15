using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    public Transform player;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position - offset;
    }
}
