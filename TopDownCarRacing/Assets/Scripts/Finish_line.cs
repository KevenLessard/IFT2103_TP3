using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_line : MonoBehaviour
{
    [SerializeField]
    private RaceLogic raceLogic;

    private void OnTriggerEnter2D(Collider2D pCollider)
    {
        //Make sure cars enter on the right side of the collider
        raceLogic.UpdateText(pCollider.name);
    }
}
