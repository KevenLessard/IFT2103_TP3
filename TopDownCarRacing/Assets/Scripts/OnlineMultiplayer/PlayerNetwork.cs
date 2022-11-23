using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
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

    private NetworkVariable<MyCustomData> randomNumber = new NetworkVariable<MyCustomData>(
        new MyCustomData
        {
            _int = 56,
            _bool = true,
        }, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    public struct MyCustomData : INetworkSerializable
    {
        public int _int;
        public bool _bool;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _int);
            serializer.SerializeValue(ref _bool);
        }
    }

    public override void OnNetworkSpawn()
    {
        randomNumber.OnValueChanged += (MyCustomData previousValue, MyCustomData newValue) =>
        {
            Debug.Log(OwnerClientId + "; " + newValue._int + "; " + newValue._bool);
        };
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.T))
        {
            randomNumber.Value = new MyCustomData
            {
                _int = 10,
                _bool = false,
            };
        }

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
