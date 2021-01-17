using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;
    public Vector3 spawnPoint;
    public List<Checkpoint> checkpoints;
    private void Awake()
    {
        //spawnPoint = new Vector3();
        checkpoints = new List<Checkpoint>();
    }
    void FixedUpdate ()
    {
        if (transform.position.y < threshold)
            transform.position = spawnPoint;
    }

    public void setSpawnPoint(Vector3 loc)
    {
        //shift the player to the left of the checkpoint
        ++loc.x;
        spawnPoint = loc;
    }
}
