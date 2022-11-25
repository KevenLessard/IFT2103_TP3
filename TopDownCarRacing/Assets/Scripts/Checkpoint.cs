using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private RaceLogic raceLogic;

    private void OnTriggerEnter2D(Collider2D other)
    {
        raceLogic.updateCheckPoints(other.name, this);
    }
}
