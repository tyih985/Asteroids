using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    public float LifeTime = 3f;

    private void Start()
    {
        Destroy(gameObject, LifeTime);
    }
}
