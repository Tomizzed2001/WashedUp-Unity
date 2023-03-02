using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    [SerializeField] float dayLength;
    [SerializeField] TimeSpan currentTime;

    [SerializeField] TimeDisplay timeDisplay;

    private float timeLength => dayLength / 1440;

    private void Start()
    {
        StartCoroutine(AddMinute());
    }

    private IEnumerator AddMinute()
    {
        currentTime += TimeSpan.FromMinutes(1);
        timeDisplay.timer = currentTime;
        timeDisplay.UpdateTime();
        yield return new WaitForSeconds(timeLength);
        StartCoroutine(AddMinute());
    }
}
