using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private TopDownCarController topDownCarController;

    private KeyCode up;
    private KeyCode down;
    private KeyCode left;
    private KeyCode right;
    void Awake()
    {
        topDownCarController = GetComponent<TopDownCarController>();
    }
    void Start()
    {
        up = KeyCode.W;
        down = KeyCode.S;
        left = KeyCode.A;
        right = KeyCode.D;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = Vector3.zero;

        if (Input.GetKey(up))
        {
            inputVector.x += 1;
        }

        if (Input.GetKey(down))
        {
            inputVector.x -= 1;
        }

        if (Input.GetKey(left))
        {
            inputVector.z += 1;
        }

        if (Input.GetKey(right))
        {
            inputVector.z -= 1;
        }
        

        topDownCarController.SetInputVector(inputVector);
    }
}
