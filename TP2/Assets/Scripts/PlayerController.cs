using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.UIElements;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private KeyCode up;
    private KeyCode down;
    private KeyCode left;
    private KeyCode right;

    public float speed;
    private Vector3 direction;
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
        if (Input.GetKey(up))
        {
            direction.z += 1;
        }
        if (Input.GetKey(down))
        {
            direction.z -= 1;
        }
        if (Input.GetKey(left))
        {
            direction.x -= 1;
        }
        if (Input.GetKey(right))
        {
            direction.x += 1;
        }

        transform.position += direction.normalized * Time.deltaTime * speed;
        direction = Vector3.zero;
    }
}
