using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualForwardFocusCamera: MonoBehaviour
{
    [SerializeField] private bool DrawLogic;
    [SerializeField] private float FocusDistance;
    [SerializeField] private float ThresholdDistance;
    public float LeftStageEdge;
    public float RightStageEdge;
    public GameObject Target;
    private CaptainController PlayerController;
    private Camera ManagedCamera;
    private LineRenderer CameraLineRenderer;
    private float LeftFocusBound;
    private float LeftThresholdBound;
    private float RightFocusBound;
    private float RightThresholdBound;
    private float BoundDistance;

    void Start()
    {
        this.CameraLineRenderer = this.gameObject.GetComponent<LineRenderer>();
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
        this.PlayerController = this.Target.GetComponent<CaptainController>();
        
        // Initial camera settings.
        this.transform.position = new Vector3(this.Target.transform.position.x, this.transform.position.y, this.transform.position.z);
        this.LeftFocusBound= this.transform.position.x - FocusDistance;
        this.LeftThresholdBound = this.transform.position.x - ThresholdDistance;
        this.RightFocusBound = this.transform.position.x + FocusDistance;
        this.RightThresholdBound = this.transform.position.x + ThresholdDistance;
    }
    
    void LateUpdate()
    {
        var cameraPosition = this.transform.position;
        var targetPosition = this.Target.transform.position;

        if ((targetPosition.x > LeftFocusBound) && (targetPosition.x < cameraPosition.x))
        {
            cameraPosition.x = targetPosition.x + FocusDistance;
            //cameraPosition = new Vector3(targetPosition.x - BoundDistance, cameraPosition.y, cameraPosition.z);
        }
        else if ((targetPosition.x < RightFocusBound) && (targetPosition.x > cameraPosition.x))
        {
            cameraPosition.x = targetPosition.x - FocusDistance;
            //cameraPosition = new Vector3(targetPosition.x + BoundDistance, cameraPosition.y, cameraPosition.z);
        }

        this.LeftFocusBound = cameraPosition.x - this.FocusDistance;
        this.LeftThresholdBound = cameraPosition.x - this.ThresholdDistance;
        this.RightFocusBound = cameraPosition.x + this.FocusDistance;
        this.RightThresholdBound = cameraPosition.x + this.ThresholdDistance;
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
        this.CameraLineRenderer.positionCount = 10;
        //this.CameraLineRenderer.useWorldSpace = false;
        this.CameraLineRenderer.SetPosition(0, new Vector3(this.LeftFocusBound, 15, -1));
        this.CameraLineRenderer.SetPosition(1, new Vector3(this.RightFocusBound, 15, -1));
        this.CameraLineRenderer.SetPosition(2, new Vector3(this.RightFocusBound, -15, -1));
        this.CameraLineRenderer.SetPosition(3, new Vector3(this.LeftFocusBound, -15, -1));
        this.CameraLineRenderer.SetPosition(4, new Vector3(this.LeftFocusBound, 15, -1));
        this.CameraLineRenderer.SetPosition(5, new Vector3(this.RightThresholdBound, 15, -1));
        this.CameraLineRenderer.SetPosition(6, new Vector3(this.RightThresholdBound, -15, -1));
        this.CameraLineRenderer.SetPosition(7, new Vector3(this.LeftThresholdBound, -15, -1));
        this.CameraLineRenderer.SetPosition(8, new Vector3(this.LeftThresholdBound, 15, -1));
        this.CameraLineRenderer.SetPosition(9, new Vector3(this.LeftFocusBound, 15, -1));
    }
}
