using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera playerCam;
    public Camera raidCam;

    private void Awake()
    {
        Instance = this;
    }

    public void UsePlayerCam()
    {
        playerCam.enabled = true;
        raidCam.enabled = false;
    }

    public void UseRaidCam()
    {
        playerCam.enabled = false;
        raidCam.enabled = true;
    }

    public GameObject player;
}
