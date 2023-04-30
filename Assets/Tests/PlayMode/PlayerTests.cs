using NUnit.Framework;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTests
{
    [UnityTest]
    public IEnumerator TestOnBuild()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<Rigidbody2D>();
        var player = gameObject.AddComponent<PlayerController>();

        player.rb.bodyType = RigidbodyType2D.Kinematic;

        player.OnBuild();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(new Vector2((float)Math.Round(2.17, 2), (float)Math.Round(1.41, 2)), new Vector2( ((float)Math.Round(player.rb.position.x, 2)) , ((float)Math.Round(player.rb.position.y, 2)) ));
    }

    [UnityTest]
    public IEnumerator TestOnDig()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<Rigidbody2D>();
        var player = gameObject.AddComponent<PlayerController>();

        player.rb.bodyType = RigidbodyType2D.Kinematic;

        player.OnDig();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return new WaitForSeconds(0.5f);

        Assert.AreEqual(new Vector2((float)Math.Round(9.54, 2), (float)Math.Round(-2.31, 2)), new Vector2(((float)Math.Round(player.rb.position.x, 2)), ((float)Math.Round(player.rb.position.y, 2))));
    }

    [UnityTest]
    public IEnumerator TestFreeze()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<Rigidbody2D>();
        var player = gameObject.AddComponent<PlayerController>();

        player.FreezeMovement();

        yield return null;

        Assert.AreEqual(true, player.freezeMovement);
    }

    [UnityTest]
    public IEnumerator TestUnFreeze()
    {
        var gameObject = new GameObject();
        gameObject.AddComponent<Rigidbody2D>();
        var player = gameObject.AddComponent<PlayerController>();

        player.FreezeMovement();

        player.UnFreezeMovement(1);

        yield return new WaitForSeconds(1.5f);

        Assert.AreEqual(false, player.freezeMovement);
    }

    [UnityTest]
    public IEnumerator TestSave()
    {
        var playerObject = new GameObject();
        var player = playerObject.AddComponent<PlayerController>();

        player.transform.position = new Vector3(5, 6, 0);

        player.SavePlayer();

        player.transform.position = new Vector3(0, 0, 0);

        player.LoadPlayer();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(new Vector3(5, 6, 0), player.transform.position);

    }


}
