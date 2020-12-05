using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : Interactable
{
    public bool isActive;
    public GameObject player;
    public GameObject checkpointObj;
    private WallRunTutorial playerController;
    public Vector3 location;
    private Renderer myRenderer;
    private Color activeColor, deActiveColor;
    // Start is called before the first frame update
    void Start()
    {
        location = checkpointObj.transform.position;
        playerController = player.GetComponent<WallRunTutorial>();
        playerController.checkpoints.Add(this);
        myRenderer = GetComponentInChildren<Renderer>();
        activeColor = new Color(0f, 1f, 0f);
        deActiveColor = new Color(1f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
            myRenderer.material.color = activeColor;
        else
            myRenderer.material.color = deActiveColor;
    }
    public void Interact()
    {
        if (!isActive)
            Activate(); 
    }
    private void Activate()
    {
        isActive = true;
        playerController.setSpawnPoint(this);
        // if any other checkpoints are currently active, deactivate them
        foreach (Checkpoint c in playerController.checkpoints)
            if (c != this && c.isActive)
                c.Deactivate();
    }
    public void Deactivate()
    {
        isActive = false;
    }


}
