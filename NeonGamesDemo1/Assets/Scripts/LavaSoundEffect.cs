using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSoundEffect : MonoBehaviour
{
    public AudioSource crackle;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            crackle.Play();
        }
    }
}
