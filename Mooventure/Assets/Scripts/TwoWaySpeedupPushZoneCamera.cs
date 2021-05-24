using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoWaySpeedupPushZoneCamera : MonoBehaviour
{
    [SerializeField] private bool DrawLogic;
    [SerializeField] private float Width;
    [SerializeField] private float PushRatio;
    public float LeftStageEdge;
    public float RightStageEdge;
    public GameObject Target;
    private CaptainController PlayerController;
    private Camera ManagedCamera;
    private LineRenderer CameraLineRenderer;

    void Start()
    {
        this.CameraLineRenderer = this.gameObject.GetComponent<LineRenderer>();
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
        this.PlayerController = this.Target.GetComponent<CaptainController>();
        
        this.transform.position = new Vector3(this.Target.transform.position.x, this.transform.position.y, this.transform.position.z);
    }
    
    void LateUpdate()
    {
        var cameraPosition = this.transform.position;
        var targetPosition = this.Target.transform.position;
        var borderDistance = Width / 2;
        var playerSpeed = this.Target.GetComponent<Rigidbody2D>().velocity.x;

        var leftBorder = cameraPosition.x - borderDistance; 
        var rightBorder = cameraPosition.x + borderDistance;
        Debug.Log("L: " + leftBorder + "\nR: " + rightBorder);

        if ((targetPosition.x >= leftBorder) && (targetPosition.x <= rightBorder))
        {
            cameraPosition.x += playerSpeed * this.PushRatio * Time.deltaTime;
        }

        if ((targetPosition.x < leftBorder) && (cameraPosition.x > LeftStageEdge))
        {
            cameraPosition.x = targetPosition.x + borderDistance;
            //cameraPosition = new Vector3(targetPosition.x - borderDistance, cameraPosition.y, cameraPosition.z);
        }
        else if ((targetPosition.x > rightBorder) && (cameraPosition.x < RightStageEdge))
        {
            cameraPosition.x = targetPosition.x - borderDistance;
            //cameraPosition = new Vector3(targetPosition.x + borderDistance, cameraPosition.y, cameraPosition.z);
        }

        this.transform.position = cameraPosition;

        if (this.DrawLogic)
        {
            this.CameraLineRenderer.enabled = true;
            this.DrawCameraLogic(); 
        }
        else
        {
            this.CameraLineRenderer.enabled = false;
        }
    }

    public void DrawCameraLogic()
    {
        this.CameraLineRenderer.positionCount = 5;
        this.CameraLineRenderer.useWorldSpace = false;
        this.CameraLineRenderer.SetPosition(0, new Vector3(-(Width/2), 15, -1));
        this.CameraLineRenderer.SetPosition(1, new Vector3((Width/2), 15, -1));
        this.CameraLineRenderer.SetPosition(2, new Vector3((Width/2), -15, -1));
        this.CameraLineRenderer.SetPosition(3, new Vector3(-(Width/2), -15, -1));
        this.CameraLineRenderer.SetPosition(4, new Vector3(-(Width/2), 15, -1));
    }
}
