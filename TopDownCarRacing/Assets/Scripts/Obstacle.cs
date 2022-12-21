using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]private GameObject mur1;
    [SerializeField]private GameObject mur2;
    [SerializeField]private GameObject murTournant;
    [SerializeField]private AudioSource closingSound;
    private int state = 1;
    

    private void OnTriggerEnter2D(Collider2D pCollider2D)
    {
        GameObject smoke = ParticlePool.instance.GetPooledSmokes();
        if (state == 1)
        {
            smoke.transform.position = murTournant.transform.position;
            playClosingSound();
            mur1.SetActive(false);
            mur2.SetActive(true);
            murTournant.SetActive(false);
            state = 2;
            smoke.SetActive(true);
            StartCoroutine(waitSmoke(2));
        }
        
        else if (state == 2)
        {
            smoke.transform.position = murTournant.transform.position;
            playClosingSound();
            mur1.SetActive(false);
            mur2.SetActive(false);
            murTournant.SetActive(true);
            state = 3;
            smoke.SetActive(true);
            StartCoroutine(waitSmoke(2));
        }
        
        else if (state == 3)
        {
            smoke.transform.position = murTournant.transform.position;
            playClosingSound();
            mur1.SetActive(false);
            mur2.SetActive(false);
            murTournant.SetActive(true);
            state = 1;
            smoke.SetActive(true);
            StartCoroutine(waitSmoke(2));
        }
        
        IEnumerator waitSmoke(int time)
        {
            yield return new WaitForSeconds(time);
            smoke.SetActive(false);
        }
    }
    private void playClosingSound()
    {
        closingSound.Play();
    }
    

}
