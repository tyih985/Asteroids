using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public int CurrentHealth = 5;
    public float CleanupDistance = 70f;
    public GameObject ExplosionVFX;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Vector3.zero);

        if (distance > CleanupDistance)
        {
            Destroy(gameObject);
        }
    }
    public void Damage(int amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(ExplosionVFX, transform.position, transform.rotation);
        }
    }

}
