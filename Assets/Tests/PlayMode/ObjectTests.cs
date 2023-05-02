using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class ObjectTests
{
    [UnityTest]
    public IEnumerator TestSave()
    {
        var gameObject = new GameObject();
        var objectManager = gameObject.AddComponent<ObjectManager>();

        var objectOne = new GameObject();
        var objectTwo = new GameObject();
        var objectThree = new GameObject();

        objectManager.objects = new GameObject[3];
        objectManager.objects[0] = objectOne;
        objectManager.objects[1] = objectTwo;
        objectManager.objects[2] = objectThree;

        bool[] testList = new bool[3];
        objectManager.activeList = testList;
        
        testList[0] = true;
        testList[1] = false;
        testList[2] = true;


        objectTwo.SetActive(false);

        objectManager.SaveObjects();

        objectManager.activeList = new bool[5];

        objectManager.LoadObjects();

        Assert.AreEqual(testList, objectManager.activeList);

        yield return null;

    }
}
