using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TimeTests
{
    [UnityTest]
    public IEnumerator TestTime()
    {
        var gameObject = new GameObject();
        var time = gameObject.AddComponent<TimeManager>();

        time.currentDay = 1;
        time.dayLength = 800;

        yield return new WaitForSeconds(2);

        Assert.AreEqual(240, time.currentTime.TotalSeconds);

    }

    [UnityTest]
    public IEnumerator TestGoNight()
    {
        var gameObject = new GameObject();
        var time = gameObject.AddComponent<TimeManager>();

        time.currentDay = 1;
        time.dayLength = 800;

        time.goNight(5);
        Assert.AreEqual(TimeSpan.FromMinutes(5), time.currentTime);

        yield return null;

    }

    [UnityTest]
    public IEnumerator TestSave()
    {
        var gameObject = new GameObject();
        var time = gameObject.AddComponent<TimeManager>();

        time.currentDay = 3;
        time.currentTime = TimeSpan.FromMinutes(50);
        time.totalSeconds = time.currentTime.TotalSeconds;
        time.dayLength = 800;
        time.SaveTime();
        time.currentDay = 5;
        time.currentTime = TimeSpan.FromMinutes(90);
        time.LoadTime();
        Assert.AreEqual(TimeSpan.FromMinutes(50), time.currentTime);

        yield return null;

    }

}
