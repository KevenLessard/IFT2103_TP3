using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]private GameObject mur1;
    [SerializeField]private GameObject mur2;
    [SerializeField]private GameObject murTournant;
    private int state = 1;

    private void OnTriggerEnter2D(Collider2D pCollider2D)
    {
        if (state == 1)
        {
            mur1.SetActive(false);
            mur2.SetActive(true);
            murTournant.SetActive(false);
            state = 2;
        }
        
        else if (state == 2)
        {
            mur1.SetActive(false);
            mur2.SetActive(false);
            murTournant.SetActive(true);
            state = 3;
        }
        
        else if (state == 3)
        {
            mur1.SetActive(false);
            mur2.SetActive(false);
            murTournant.SetActive(true);
            state = 1;
        }


    }
}
