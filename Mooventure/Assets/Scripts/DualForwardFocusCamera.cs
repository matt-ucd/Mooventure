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
    private PlayerController PlayerController;
    private Camera ManagedCamera;
    private LineRenderer CameraLineRenderer;
    private float LeftFocusBound;
    private float LeftThresholdBound;
    private float RightFocusBound;
    private float RightThresholdBound;
    private float Interpolant;
    private float LerpTimer;
    private float CameraOffsetX;
    private bool AtScreenEdge = false;
    private bool IsLerping = false;
    private Vector3 CameraPosition;
    private Vector3 CameraFrom;

    void Start()
    {
        // Set primary objects.
        this.CameraLineRenderer = this.gameObject.GetComponent<LineRenderer>();
        this.ManagedCamera = this.gameObject.GetComponent<Camera>();
        this.PlayerController = this.Target.GetComponent<PlayerController>();
        
        // Initial camera settings.
        this.CameraPosition = new Vector3(this.Target.transform.position.x - FocusDistance, this.transform.position.y, this.transform.position.z);
        this.LeftThresholdBound = this.CameraPosition.x - this.ThresholdDistance;
        this.LeftFocusBound = this.CameraPosition.x - this.FocusDistance;
        this.RightFocusBound = this.transform.position.x + this.FocusDistance;
        this.RightThresholdBound = this.transform.position.x + this.ThresholdDistance;
    }
    
    void LateUpdate()
    {
        var targetPosition = this.Target.transform.position;

        // Check which side of the screen the player is currently located to
        // determine which set of bounds to check
        if (targetPosition.x < this.CameraPosition.x)
        {
            // If the player is on the left side, check the left bounds.
            if (targetPosition.x > this.LeftFocusBound && !AtScreenEdge)
            {
                this.CameraPosition.x = targetPosition.x + this.FocusDistance;
            }
            else if ((targetPosition.x < this.LeftThresholdBound) && !IsLerping)
            {
                this.LerpTimer = 0;
                this.IsLerping = true;
                this.CameraFrom = this.CameraPosition;
                this.CameraOffsetX = -FocusDistance;
                this.AtScreenEdge = false;
                //this.CameraPosition.x = targetPosition.x - FocusDistance;
            }
        }
        else
        {
            // If the player is on the right side, check the right bounds.
            if (targetPosition.x < this.RightFocusBound && !AtScreenEdge)
            {
                this.CameraPosition.x = targetPosition.x - this.FocusDistance;
            }
            else if ((targetPosition.x > this.RightThresholdBound) && !IsLerping)
            {
                this.LerpTimer = 0;
                this.IsLerping = true;
                this.CameraFrom = this.CameraPosition;
                this.CameraOffsetX = FocusDistance;
                this.AtScreenEdge = false;
                //this.CameraPosition.x = targetPosition.x + FocusDistance;
            }
        }

        // Update timing and interpolant.
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

        // If the camera has exceeded the bound of the level, reset it to the stage edge.
        if (this.CameraPosition.x < LeftStageEdge)
        {
            this.CameraPosition.x = LeftStageEdge;
            this.IsLerping = false;
            this.AtScreenEdge = true;

        }
        else if (this.CameraPosition.x > RightStageEdge)
        {
            this.CameraPosition.x = RightStageEdge;
            this.IsLerping = false;
            this.AtScreenEdge = true;
        }

        // Update the camera bounds.
        this.LeftFocusBound = this.CameraPosition.x - this.FocusDistance;
        this.LeftThresholdBound = this.CameraPosition.x - this.ThresholdDistance;
        this.RightFocusBound = this.CameraPosition.x + this.FocusDistance;
        this.RightThresholdBound = this.CameraPosition.x + this.ThresholdDistance;

        // Reposition the camera.
        this.transform.position = this.CameraPosition;

        // If enabled, draw line renderer to show camera bounds.
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
