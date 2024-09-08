using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody Rigidbody;
    public float Thrust = 30;
    public float Turning = 30;
    public float TurboBoostMultiplier = 2f;

    [Header("Weapons")]
    public Laser LaserPrefab;
    public Transform[] LaserMuzzles;
    public float LaserCooldown = 0.2f;

    private float laserTimer;
    private int hp = 3;

    private void Update()
    {
        // increment laser timer - using frame time
        laserTimer += Time.deltaTime;

        // check for player input and laser cooldown
        if (Input.GetButton("Fire1") && laserTimer > LaserCooldown)
        {
            laserTimer = 0;

            Shoot();
        }
    }

    private void Shoot()
    {
        for (int i = 0; i < LaserMuzzles.Length; i++)
        {
            Transform muzzle = LaserMuzzles[i];
            Instantiate(LaserPrefab, muzzle.position, muzzle.rotation);
        }
    }

    private void FixedUpdate()
    {
        float move = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");

        float currentThrust = Input.GetKey(KeyCode.Space) ? Thrust * TurboBoostMultiplier : Thrust;

        Rigidbody.AddForce(move * currentThrust * transform.forward);
        Rigidbody.AddTorque(rotate * Turning * transform.up);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // try to get asteroid component on other object
        Asteroid asteroid = collision.collider.GetComponent<Asteroid>();

        // we null check component to see if it exists
        if (asteroid != null)
        {
            // we hit an asteroid :(
            hp--;
            if (hp == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
