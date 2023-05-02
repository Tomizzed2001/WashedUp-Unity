using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class HouseTests
{
    [UnityTest]
    public IEnumerator TestSave()
    {
        var gameObject = new GameObject();
        var house = gameObject.AddComponent<BuildArea>();

        house.buildingComplete = true;

        house.SaveHouse();

        house.buildingComplete = false;

        house.LoadHouse();

        Assert.AreEqual(true, house.buildingComplete);

        yield return null;

    }
}
