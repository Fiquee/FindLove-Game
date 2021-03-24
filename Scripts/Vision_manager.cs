using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Vision_manager : MonoBehaviour
{
    public static Vision_manager instance;
    private GameObject light_control;
    public float maxvision_inner;
    public float maxvision_outer;
    public float minvision_inner;
    public float minvision_outer;
    public bool isEnding;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        light_control = GameObject.FindGameObjectWithTag("playerLight");
        if (light_control != null)
        {
            light_control.GetComponent<Light2D>().pointLightInnerRadius = maxvision_inner;
            light_control.GetComponent<Light2D>().pointLightOuterRadius = maxvision_outer;
        }

    }
    private void Update()
    {
        if (isEnding)
        {
            return;
        }
        light_control = GameObject.FindGameObjectWithTag("playerLight");
    }

    public void reduceVision(float decrement_percent)
    {
        light_control.GetComponent<Light2D>().pointLightInnerRadius *= decrement_percent;
        if (light_control.GetComponent<Light2D>().pointLightInnerRadius < minvision_inner)
        {
            light_control.GetComponent<Light2D>().pointLightInnerRadius = minvision_inner;
        }
        light_control.GetComponent<Light2D>().pointLightOuterRadius = light_control.GetComponent<Light2D>().pointLightOuterRadius * decrement_percent * decrement_percent * decrement_percent;
        if (light_control.GetComponent<Light2D>().pointLightOuterRadius < minvision_outer)
        {
            light_control.GetComponent<Light2D>().pointLightOuterRadius = minvision_outer;
        }
    }

    public void SetVisionInner(float radius)
    {
        light_control.GetComponent<Light2D>().pointLightInnerRadius = radius;
    }

    public void SetVisionOuter(float radius)
    {
        light_control.GetComponent<Light2D>().pointLightOuterRadius = radius;
    }

    public void resetVision()
    {
        if (light_control != null)
        {
            light_control.GetComponent<Light2D>().pointLightInnerRadius = maxvision_inner;
            light_control.GetComponent<Light2D>().pointLightOuterRadius = maxvision_outer;
        }

    }
}
