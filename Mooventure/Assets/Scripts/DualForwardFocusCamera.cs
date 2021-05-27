using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualForwardFocusCamera: MonoBehaviour
{
    [SerializeField] private bool DrawLogic;
    [SerializeField] private float FocusDistance;
    [SerializeField] private float ThresholdDistance;
    [SerializeField] private float LerpDuration;
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
    private float Interpolant;
    private float LerpTimer;
    private float CameraOffsetX;
    private bool IsLerping = false;
    private Vector3 CameraPosition;
    private Vector3 CameraFrom;

    void Start()
    {
        this.CameraLineRenderer = this.gameObject.GetComponent<LineRenderer>();
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
        this.PlayerController = this.Target.GetComponent<CaptainController>();
        
        // Initial camera settings.
        /*
        this.transform.position = new Vector3(this.Target.transform.position.x - FocusDistance, this.transform.position.y, this.transform.position.z);
        this.LeftFocusBound= this.transform.position.x - FocusDistance;
        this.LeftThresholdBound = this.transform.position.x - ThresholdDistance;
        this.RightFocusBound = this.transform.position.x + FocusDistance;
        this.RightThresholdBound = this.transform.position.x + ThresholdDistance;
        */
        this.CameraPosition = new Vector3(this.Target.transform.position.x - FocusDistance, this.transform.position.y, this.transform.position.z);
        this.LeftThresholdBound = this.CameraPosition.x - this.ThresholdDistance;
        this.LeftFocusBound = this.CameraPosition.x - this.FocusDistance;
        this.RightFocusBound = this.transform.position.x + this.FocusDistance;
        this.RightThresholdBound = this.transform.position.x + this.ThresholdDistance;
    }
    
    void LateUpdate()
    {
        var targetPosition = this.Target.transform.position;

        if (targetPosition.x < this.CameraPosition.x)
        {
            if (targetPosition.x > this.LeftFocusBound)
            {
                this.CameraPosition.x = targetPosition.x + this.FocusDistance;
            }
            else if ((targetPosition.x < this.LeftThresholdBound) && !IsLerping)
            {
                this.LerpTimer = 0;
                this.IsLerping = true;
                this.CameraFrom = this.CameraPosition;
                this.CameraOffsetX = -FocusDistance;
                //this.CameraPosition.x = targetPosition.x - FocusDistance;
            }
        }
        else
        {
            if (targetPosition.x < this.RightFocusBound)
            {
                this.CameraPosition.x = targetPosition.x - this.FocusDistance;
            }
            else if ((targetPosition.x > this.RightThresholdBound) && !IsLerping)
            {
                this.LerpTimer = 0;
                this.IsLerping = true;
                this.CameraFrom = this.CameraPosition;
                this.CameraOffsetX = FocusDistance;
                //this.CameraPosition.x = targetPosition.x + FocusDistance;
            }
        }

        // Update timing, interpolant.
        this.LerpTimer += Time.deltaTime;
        this.Interpolant = this.LerpTimer / this.LerpDuration;

        // If the camera has started to lerp, override any other changes and move to lerp position.
        if (IsLerping)
        {
            Vector3 cameraTo = new Vector3(targetPosition.x + this.CameraOffsetX, this.CameraPosition.y, this.CameraPosition.z);
            this.CameraPosition = Vector3.Lerp(this.CameraFrom, cameraTo, this.Interpolant);

            // Once the timer has exceeded the lerp duration, end the lerp.
            if (this.LerpTimer >= this.LerpDuration)
            {
                this.IsLerping = false;
            }
        }

        // Update the camera bounds.
        this.LeftFocusBound = this.CameraPosition.x - this.FocusDistance;
        this.LeftThresholdBound = this.CameraPosition.x - this.ThresholdDistance;
        this.RightFocusBound = this.CameraPosition.x + this.FocusDistance;
        this.RightThresholdBound = this.CameraPosition.x + this.ThresholdDistance;

        this.transform.position = this.CameraPosition;

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
