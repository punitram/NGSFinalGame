using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    // Start is called before the first frame update
    public int forceUp = 800;
    public int forceForward = 300;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject block = collision.gameObject;
        Rigidbody rb = block.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * forceUp);
        rb.AddForce(Vector3.forward * forceForward);

    }
}
