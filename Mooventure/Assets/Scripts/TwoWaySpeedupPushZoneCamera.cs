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
    private float LeftBound;
    private float RightBound;
    private float BoundDistance;

    void Start()
    {
        this.CameraLineRenderer = this.gameObject.GetComponent<LineRenderer>();
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
        this.PlayerController = this.Target.GetComponent<CaptainController>();
        
        // Initial camera settings.
        this.BoundDistance = this.Width / 2;
        this.transform.position = new Vector3(this.Target.transform.position.x, this.transform.position.y, this.transform.position.z);
        this.LeftBound = this.transform.position.x - BoundDistance;
        this.RightBound = this.transform.position.x + BoundDistance;
    }
    
    void LateUpdate()
    {
        var cameraPosition = this.transform.position;
        var targetPosition = this.Target.transform.position;
        var playerSpeed = this.Target.GetComponent<Rigidbody2D>().velocity.x;

        if ((targetPosition.x >= LeftBound) && (targetPosition.x <= RightBound))
        {
            cameraPosition.x += playerSpeed * this.PushRatio * Time.deltaTime;
        }

        if ((targetPosition.x < LeftBound) && (cameraPosition.x > LeftStageEdge))
        {
            cameraPosition.x = targetPosition.x + BoundDistance;
            //cameraPosition = new Vector3(targetPosition.x - BoundDistance, cameraPosition.y, cameraPosition.z);
        }
        else if ((targetPosition.x > RightBound) && (cameraPosition.x < RightStageEdge))
        {
            cameraPosition.x = targetPosition.x - BoundDistance;
            //cameraPosition = new Vector3(targetPosition.x + BoundDistance, cameraPosition.y, cameraPosition.z);
        }

        this.LeftBound = cameraPosition.x - this.BoundDistance;
        this.RightBound = cameraPosition.x + this.BoundDistance;
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
        //this.CameraLineRenderer.useWorldSpace = false;
        this.CameraLineRenderer.SetPosition(0, new Vector3(this.LeftBound, 15, -1));
        this.CameraLineRenderer.SetPosition(1, new Vector3(this.RightBound, 15, -1));
        this.CameraLineRenderer.SetPosition(2, new Vector3(this.RightBound, -15, -1));
        this.CameraLineRenderer.SetPosition(3, new Vector3(this.LeftBound, -15, -1));
        this.CameraLineRenderer.SetPosition(4, new Vector3(this.LeftBound, 15, -1));
    }
}
