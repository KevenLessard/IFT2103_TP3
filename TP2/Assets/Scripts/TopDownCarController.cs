using System;
using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class TopDownCarController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float steering;

    private Vector3 inputVector;

    private Rigidbody rigidBody;
    private Vector3 currentSpeed;
 
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        currentSpeed = Vector3.zero;
    }
 
    private void FixedUpdate()
    {
        Vector3 speed = transform.up * (inputVector.x * acceleration);
        rigidBody.AddForce(speed);
        rigidBody.transform.Rotate(new Vector3(0, 0, inputVector.z * steering * (rigidBody.velocity.magnitude / maxSpeed)));

    }

    public void SetInputVector(Vector3 p_inputVector)
    {
        inputVector = p_inputVector;
    }
}
