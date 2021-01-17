using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Interactable
{
    public bool isActive;
    public GameObject player;
    public GameObject checkpointObj;
    private PlayerMovement pm;
    public Vector3 location;
    // Start is called before the first frame update
    void Start()
    {
        location = transform.position;
        pm = player.GetComponent<PlayerMovement>();
        pm.checkpoints.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Activate()
    {
        isActive = true;
        pm.setSpawnPoint(this);
        // if any other checkpoints are currently active, deactivate them
        foreach (Checkpoint c in pm.checkpoints)
            if (c != this && c.isActive)
                c.Deactivate();
    }
    public void Deactivate()
    {
        isActive = false;
    }
}
