using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnLava : MonoBehaviour
{
    private Vector3 spawnPoint = new Vector3(6, 12, 0);

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Lava"))
        {
            transform.position = spawnPoint;
        }
    }
}