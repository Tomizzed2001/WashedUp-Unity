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
    public Camera currentCam;
    public GameObject player;

    [Header("Game Settings")]
    [SerializeField]
    public bool inRaid = false;
    public int GameHealth;
    public bool isGameOver = false;

    [Header("Game Screens")]
    [SerializeField] public GameOver gameOver;
    [SerializeField] private GameWin gameWin;

    [Header("Managers")]
    [SerializeField] public AudioManager audioManager;
    [SerializeField] public ObjectivesManager objectivesManager;
    [SerializeField] public UIManager uiManager;

    [Header("Objective Helper Variables")]
    [SerializeField] public bool chestOpened;

    private void Awake()
    {
        Instance = this;
        currentCam = playerCam;
    }

    public void UsePlayerCam()
    {
        inRaid = false;
        currentCam = playerCam;
        playerCam.enabled = true;
        raidCam.enabled = false;
    }

    public void UseRaidCam()
    {
        inRaid = true;
        currentCam = raidCam;
        playerCam.enabled = false;
        raidCam.enabled = true;
    }

    public void LoseHealth()
    {
        GameHealth--;
        uiManager.Health2.text = GameHealth.ToString();
        if (GameHealth <= 0)
        {
            isGameOver = true;
            gameOver.GameEnd();
        }
    }

    public void GameWin()
    {
        gameWin.GameWon();
    }

    public void SaveGame()
    {
        Save.SaveGame(GameHealth);
    }

    public void LoadGame()
    {
        GameData data = Save.LoadGame();
        GameHealth = data.health;
        uiManager.Health2.text = GameHealth.ToString();
    }

}
