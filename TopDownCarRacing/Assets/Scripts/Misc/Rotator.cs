using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(_rotation * _speed * Time.deltaTime);
    }
}
