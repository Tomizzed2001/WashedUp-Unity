using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TestBoat
{
    [UnityTest]
    public IEnumerator TestSaveTier()
    {
        var gameObject = new GameObject();
        var boat = gameObject.AddComponent<Boat>();

        boat.boatTier = 5;

        boat.SaveBoat();

        boat.boatTier = 2;

        boat.LoadBoat();

        Assert.AreEqual(5, boat.boatTier);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestSaveFixToday()
    {
        var gameObject = new GameObject();
        var boat = gameObject.AddComponent<Boat>();

        boat.fixedToday = true;

        boat.SaveBoat();

        boat.fixedToday = false;

        boat.LoadBoat();

        Assert.AreEqual(true, boat.fixedToday);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestSaveFixed()
    {
        var gameObject = new GameObject();
        var boat = gameObject.AddComponent<Boat>();

        boat.boatFixed = true;

        boat.SaveBoat();

        boat.boatFixed = false;

        boat.LoadBoat();

        Assert.AreEqual(true, boat.boatFixed);

        yield return null;
    }
}
