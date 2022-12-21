using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    public static ParticlePool instance;

    private List<GameObject> poolSmokes = new List<GameObject>();
    private List<GameObject> poolCelebration = new List<GameObject>();
    private int amountToPool = 3;

    [SerializeField] private GameObject smokePrefab;
    [SerializeField] private GameObject celebrationPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(smokePrefab);
            obj.SetActive(false);
            poolSmokes.Add(obj);
        }
        
        for (int i = 0; i < 1; i++)
        {
            GameObject obj = Instantiate(celebrationPrefab);
            obj.SetActive(false);
            poolCelebration.Add(obj);
        }
    }

    public GameObject GetPooledSmokes()
    {
        for (int i = 0; i < poolSmokes.Count; i++)
        {
            if (!poolSmokes[i].activeInHierarchy)
            {
                return poolSmokes[i];
            }
        }
        return null;
    }
    
    public GameObject GetPooledCelebration()
    {
        for (int i = 0; i < poolSmokes.Count; i++)
        {
            if (!poolCelebration[i].activeInHierarchy)
            {
                return poolCelebration[i];
            }
        }
        return null;
    }
}
