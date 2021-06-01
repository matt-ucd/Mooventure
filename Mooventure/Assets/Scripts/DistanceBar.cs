using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceBar : MonoBehaviour
{
    public float leftBorder;
    [SerializeField] Transform Player;
    [SerializeField] Transform Goal;
    [SerializeField] Slider distanceSlider;

    float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        maxDistance = Goal.position.x - leftBorder;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.position.x <= maxDistance && Player.position.x <= Goal.position.x)
        {
            float distance = 1-(getDistance() / maxDistance);
            setSliderPos(distance);
        }  
    }

    float getDistance()
    {
        //Debug.Log(Goal.position.x - Player.position.x);
        return (Goal.position.x - Player.position.x);
    }

    void setSliderPos(float sliderPos)
    {
        distanceSlider.value = sliderPos;
    }
}
