using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputExample : MonoBehaviour
{
    // inspector in Unity has access to public variables
    public Vector3 PlayerInput;
    public Rigidbody Rigidbody;
    public float Acceleration = 10;

    private void FixedUpdate()
    {
        // read keyboard input from player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // assign input to 3D world space input
        PlayerInput = new Vector3(horizontal, 0, vertical);

        // calculate movement force
        Vector3 force = PlayerInput * Acceleration;

        // add force to rigidbody
        Rigidbody.AddForce(force);
    }
}
