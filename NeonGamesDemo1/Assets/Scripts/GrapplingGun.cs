using UnityEngine;
using UnityEngine.EventSystems;

public class GrapplingGun : MonoBehaviour {

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    public float maxDistance = 100f;
    private SpringJoint joint;

    public float maxDistanceModifier = 0.8f;
    public float minDistanceModifier = 0.25f;
    public float springAmount = 4.5f;
    public float damperAmount = 7f;
    public float massScale = 4.5f;

    void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            //if (EventSystem.current.IsPointerOverGameObject())
                //return;
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0)) {
            StopGrapple();
        }
    }

    //Called after Update
    void LateUpdate() {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * maxDistanceModifier;
            joint.minDistance = distanceFromPoint * minDistanceModifier;

            //Adjust these values to fit your game.
            joint.spring = springAmount;
            joint.damper = damperAmount;
            joint.massScale = massScale;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple() {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;
    
    void DrawRope() {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);
        
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling() {
        return joint != null;
    }

    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }
}
