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

    [Header("Recipes")]
    [SerializeField] private GameObject[] recipes;
         
    [Header("Things to save")]
    [SerializeField] public bool recipesEnabled;
    [SerializeField] public bool wreckageActive;
    

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
            audioManager.StopRaid();
            audioManager.GameLose();
            gameOver.GameEnd();
            
        }
    }

    public void GameWin()
    {
        audioManager.StopRaid();
        audioManager.GameWin();
        gameWin.GameWon();
    }

    public void EnableRecipes()
    {
        recipesEnabled = true;
        for (int i = 0; i < recipes.Length; i++)
        {
            recipes[i].SetActive(true);
        }
    }

    public void SaveGame()
    {
        Save.SaveGame(GameHealth, recipesEnabled, wreckageActive);
    }

    public void LoadGame()
    {
        GameData data = Save.LoadGame();
        GameHealth = data.health;
        recipesEnabled = data.recipes;
        wreckageActive = data.wreckage;
        uiManager.Health2.text = GameHealth.ToString();
        if (GameHealth <= 0)
        {
            gameOver.GameEnd();
        }
        if (data.recipes)
        {
            EnableRecipes();
        }
        if(data.wreckage)
        {
            objectivesManager.ShowWreckage();
        }
    }

}
