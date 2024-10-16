using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling<T> : Singleton<T> where T : MonoBehaviour
{
    private static ObjectPooling<T> _instant;
    public static ObjectPooling<T> Instant => _instant;

    

}
