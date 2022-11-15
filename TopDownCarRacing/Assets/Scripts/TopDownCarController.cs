using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCarController : MonoBehaviour
{
    
    public float maxSpeed;
    public float acceleration;
    public float steering;
 
    private Rigidbody2D rb;
    private float currentSpeed;

    private float accelerationInput;
    private float steeringInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
 
    private void FixedUpdate()
    {
        GetInput();

        // Calculate speed from input and acceleration (transform.up is forward)
        Vector2 speed = transform.up * (accelerationInput * acceleration);
        rb.AddForce(speed);
 
        // Create car rotation
        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
        if (direction >= 0.0f)
        {
            rb.rotation += steeringInput * steering * (rb.velocity.magnitude / maxSpeed);
        }
        else
        {
            rb.rotation -= steeringInput * steering * (rb.velocity.magnitude / maxSpeed);
        }
 
        // Change velocity based on rotation
        float driftForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * driftForce;
        rb.AddForce(rb.GetRelativeVector(relativeForce));
 
        // Force max speed limit
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        currentSpeed = rb.velocity.magnitude;
    }

    private void GetInput()
    {
        
    }
}
