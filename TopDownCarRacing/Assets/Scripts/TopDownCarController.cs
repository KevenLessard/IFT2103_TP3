using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TopDownCarController : MonoBehaviour
{
    [SerializeField] private Inputs inputs;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float steering;
    [SerializeField] private float speedBoostTime;
    private float _maxSpeed;
    private float _acceleration;

    private Rigidbody2D _rb;

    private Coroutine _speedBoost;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _maxSpeed = maxSpeed;
        _acceleration = acceleration;
    }
 
    private void FixedUpdate()
    {
        Vector2 inputs = GetInput();

        // Calculate speed from input and acceleration (transform.up is forward)
        Vector2 speed = transform.up * (inputs.x * _acceleration);
        _rb.AddForce(speed);
        
        // Create car rotation
        float direction = Vector2.Dot(_rb.velocity, _rb.GetRelativeVector(Vector2.up));
        if (direction >= 0.0f)
        {
            _rb.rotation += inputs.y * steering * (_rb.velocity.magnitude / _maxSpeed);
        }
        else
        {
            _rb.rotation -= inputs.y * steering * (_rb.velocity.magnitude / _maxSpeed);
        }
 
        // Change velocity based on rotation
        float driftForce = Vector2.Dot(_rb.velocity, _rb.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * driftForce;
        _rb.AddForce(_rb.GetRelativeVector(relativeForce));
 
        // Force max speed limit
        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GoldenSnitch")
        {
            AudioGoldenSnitch.Instance.playActivation();
            if (_speedBoost != null)
            {
                StopCoroutine(_speedBoost);
                _speedBoost = null;
            }
            _speedBoost = StartCoroutine(SpeedBoost());
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

    IEnumerator SpeedBoost()
    {
        _maxSpeed = maxSpeed * 1.5f;
        _acceleration = _maxSpeed;
        yield return new WaitForSeconds(speedBoostTime);
        _maxSpeed = maxSpeed;
        _acceleration = acceleration;
        _speedBoost = null;
    }
}
