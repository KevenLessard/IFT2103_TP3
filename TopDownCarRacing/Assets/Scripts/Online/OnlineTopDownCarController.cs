using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class OnlineTopDownCarController : NetworkBehaviour
{
    [SerializeField] private Inputs inputs;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float steering;
 
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


 
    private void FixedUpdate()
    {
        Vector2 inputs = GetInput();

        // Calculate speed from input and acceleration (transform.up is forward)
        Vector2 speed = transform.up * (inputs.x * acceleration);
        _rb.AddForce(speed);
 
        // Create car rotation
        float direction = Vector2.Dot(_rb.velocity, _rb.GetRelativeVector(Vector2.up));
        if (direction >= 0.0f)
        {
            _rb.rotation += inputs.y * steering * (_rb.velocity.magnitude / maxSpeed);
        }
        else
        {
            _rb.rotation -= inputs.y * steering * (_rb.velocity.magnitude / maxSpeed);
        }
 
        // Change velocity based on rotation
        float driftForce = Vector2.Dot(_rb.velocity, _rb.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * driftForce;
        _rb.AddForce(_rb.GetRelativeVector(relativeForce));
 
        // Force max speed limit
        if (_rb.velocity.magnitude > maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * maxSpeed;
        }
    }
    
    public override void OnNetworkSpawn()
    {
        if (!IsOwner)
        {
            Destroy(this);
        }
        
    }
    
    private Vector2 GetInput()
    {
        Vector2 playerInputs = Vector2.zero;

        if (Input.GetKey(inputs._playerInputs[0]))
        {
            playerInputs.x += 1;
        }

        if (Input.GetKey(inputs._playerInputs[1]))
        {
            playerInputs.x -= 1;
        }

        if (Input.GetKey(inputs._playerInputs[2]))
        {
            playerInputs.y += 1;
        }

        if (Input.GetKey(inputs._playerInputs[3]))
        {
            playerInputs.y -= 1;
        }

        return playerInputs;
    }
}
