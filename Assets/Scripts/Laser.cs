using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Laser : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float Speed = 30;

    private void Start()
    {
        Rigidbody.velocity = transform.forward * Speed;
    }

    // we use OnTriggerEnter for colliders flagged as a trigger
    private void OnTriggerEnter(Collider other)
    {
        Asteroid asteroid = other.GetComponent<Asteroid>();
        if (asteroid != null)
        {
            Destroy(gameObject);
            asteroid.Damage(1);
        }
    }
}
