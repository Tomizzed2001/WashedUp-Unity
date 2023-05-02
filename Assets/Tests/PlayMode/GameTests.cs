using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class GameTests
{
    [UnityTest]
    public IEnumerator TestSwapCameraPlayer()
    {
        var gameObject = new GameObject();
        var gameManager = gameObject.AddComponent<GameManager>();

        var playerCamera = new GameObject();
        playerCamera.AddComponent<Camera>();
        var raidCamera = new GameObject();
        raidCamera.AddComponent<Camera>();

        gameManager.playerCam = playerCamera.GetComponent<Camera>();
        gameManager.raidCam = raidCamera.GetComponent<Camera>();

        gameManager.UsePlayerCam();

        Assert.AreEqual(playerCamera.GetComponent<Camera>(), gameManager.currentCam);

        yield return null;

    }

    [UnityTest]
    public IEnumerator TestSwapCameraRaid()
    {
        var gameObject = new GameObject();
        var gameManager = gameObject.AddComponent<GameManager>();

        var playerCamera = new GameObject();
        playerCamera.AddComponent<Camera>();
        var raidCamera = new GameObject();
        raidCamera.AddComponent<Camera>();

        gameManager.playerCam = playerCamera.GetComponent<Camera>();
        gameManager.raidCam = raidCamera.GetComponent<Camera>();

        gameManager.UseRaidCam();

        Assert.AreEqual(raidCamera.GetComponent<Camera>(), gameManager.currentCam);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestSaveHealth()
    {
        var gameObject = new GameObject();
        var gameManager = gameObject.AddComponent<GameManager>();

        gameManager.GameHealth = 5;

        gameManager.SaveGame();

        gameManager.GameHealth = 2;

        gameManager.LoadGame();

        Assert.AreEqual(5, gameManager.GameHealth);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestSaveRecipesOne()
    {
        var gameObject = new GameObject();
        var gameManager = gameObject.AddComponent<GameManager>();
        gameManager.recipes = new GameObject[0];

        gameManager.recipesEnabled = true;

        gameManager.SaveGame();

        gameManager.recipesEnabled = false;

        gameManager.LoadGame();

        Assert.AreEqual(true, gameManager.recipesEnabled);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestSaveRecipesTwo()
    {
        var gameObject = new GameObject();
        var gameManager = gameObject.AddComponent<GameManager>();
        gameManager.recipes2 = new GameObject[0];

        gameManager.recipes2Enabled = true;

        gameManager.SaveGame();

        gameManager.recipes2Enabled = false;

        gameManager.LoadGame();

        Assert.AreEqual(true, gameManager.recipes2Enabled);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestSaveWreckage()
    {
        var gameObject = new GameObject();
        var gameManager = gameObject.AddComponent<GameManager>();

        gameManager.wreckageActive = true;

        gameManager.SaveGame();

        gameManager.wreckageActive = false;

        gameManager.LoadGame();

        Assert.AreEqual(true, gameManager.wreckageActive);

        yield return null;
    }

    [UnityTest]
    public IEnumerator TestSaveInLand()
    {
        var gameObject = new GameObject();
        var gameManager = gameObject.AddComponent<GameManager>();

        gameManager.inLand = true;

        gameManager.SaveGame();

        gameManager.inLand = false;

        gameManager.LoadGame();

        Assert.AreEqual(true, gameManager.inLand);

        yield return null;
    }

}
