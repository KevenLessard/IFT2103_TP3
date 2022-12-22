using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdVolume : MonoBehaviour
{
    [SerializeField] private AudioSource crowdCheeringAudio = null;
    
    public static CrowdVolume Instance;
    private void Awake()
    {
        Instance = FindObjectOfType<CrowdVolume>();
    }
    
    public void setCrowdCheeringVolume(float value)
    {
        crowdCheeringAudio.volume = value;
    }
}
