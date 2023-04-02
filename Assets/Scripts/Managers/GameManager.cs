using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player objects")]
    [SerializeField]
    public Camera playerCam;
    public Camera raidCam;
    public GameObject player;

    [Header("Game Settings")]
    [SerializeField]
    public int GameHealth;
    public bool isGameOver = false;

    [Header("Game Screens")]
    [SerializeField] private GameOver gameOver;

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

    public void LoseHealth()
    {
        GameHealth--;
        if (GameHealth <= 0)
        {
            isGameOver = true;
            gameOver.GameEnd();
        }
    }

}
