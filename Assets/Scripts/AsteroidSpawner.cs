using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Rigidbody[] AsteroidPrefabs;
    public float Radius = 60f;
    public Vector2 SpeedRange = new Vector2(15, 25);
    public float StartSpawnPeriod = 1;

    private void Start()
    {
        SpawnAsteroid();
    }

    private void SpawnAsteroid()
    {
        Vector3 from = GetRandomPointOnCircle();
        Vector3 to = GetRandomPointOnCircle();
        Debug.DrawLine(from, to, Color.red, 1f);

        // select random asteroid prefab
        int index = Random.Range(0, AsteroidPrefabs.Length);
        Rigidbody prefab = AsteroidPrefabs[index];
        Rigidbody asteroid = Instantiate(prefab, from, Random.rotation);
        float speed = Random.Range(SpeedRange.x, SpeedRange.y);
        Vector3 direction = (to -  from).normalized;
        asteroid.velocity = direction * speed;

        Invoke("SpawnAsteroid", StartSpawnPeriod);
    }

    private Vector3 GetRandomPointOnCircle()
    {
        float angle = Random.Range(0f, 360f);
        float x = Mathf.Cos(angle);
        float z = Mathf.Sin(angle);
        Vector3 position = new Vector3(x, 0, z) * Radius;
        return position;
    }

    // this is for visual debugging
    private void OnDrawGizmos()
    {
        // draw a wire sphere representing spawn radius
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
