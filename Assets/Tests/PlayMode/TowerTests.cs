using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class TowerTests
{
    [UnityTest]
    public IEnumerator TestBuild()
    {
        var gameObject = new GameObject();

        var towerManager = gameObject.AddComponent<TowerManager>();

        GameObject towerObject = new GameObject();
        towerObject.name = "tower";
        towerObject.AddComponent<Tower>();

        towerManager.Defences = new GameObject[1];
        towerManager.Defences[0] = towerObject;

        GameObject placement = new GameObject();
        placement.transform.position = new Vector3(2f, 3f, 0f);

        towerManager.PlacementZone = placement.transform;

        towerManager.Build("tower");

        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(1f);

        Tower[] newTower = GameObject.FindObjectsOfType<Tower>();
        
        Assert.AreEqual(2, newTower.Length);
    }

    [UnityTest]
    public IEnumerator TestSave()
    {
        var gameObject = new GameObject();
        var towerManager = gameObject.AddComponent<TowerManager>();

        GameObject towerObject = new GameObject();
        towerObject.name = "ArcherTower";
        towerObject.AddComponent<Tower>();
        towerObject.GetComponent<Tower>().towerName = "ArcherTower";
        towerObject.transform.position = new Vector3(2f, 4f, 0f);

        towerManager.Defences = new GameObject[1];
        towerManager.Defences[0] = towerObject;

        towerManager.SaveTowers();

        towerObject.transform.position = new Vector3(0f, 0f, 0f);

        yield return new WaitForSeconds(1f);

        towerManager.LoadTowers();
        towerObject.SetActive(false);

        yield return new WaitForSeconds(1f);

        Tower newTower = GameObject.FindObjectOfType<Tower>();

        Assert.AreEqual(new Vector3(2, 4, 0), newTower.transform.position);
    }
}
