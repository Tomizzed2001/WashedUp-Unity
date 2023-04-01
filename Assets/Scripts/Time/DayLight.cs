using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]


public class DayLight : MonoBehaviour
{
    private Light2D daylight;

    [SerializeField] TimeManager worldTime;
    [SerializeField] Gradient gradient;

    private void Awake()
    {
        daylight = GetComponent<Light2D>();
        daylight.color = gradient.Evaluate(PercentOfDay(worldTime.currentTime));
    }

    public void UpdateLights()
    {
        daylight.color = gradient.Evaluate(PercentOfDay(worldTime.currentTime));
    }

    private float PercentOfDay(TimeSpan timeSpan)
    {
        return (float)timeSpan.TotalMinutes % 1440 / 1440 ;
    }
}
