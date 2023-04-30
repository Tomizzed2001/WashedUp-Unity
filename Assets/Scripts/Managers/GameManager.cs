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
    [SerializeField] private GameObject[] recipes2;

    [Header("Things to save")]
    [SerializeField] public bool recipesEnabled;
    [SerializeField] public bool recipes2Enabled;
    [SerializeField] public bool wreckageActive;
    [SerializeField] public bool inLand = false;
    [SerializeField] public bool gameWon;

    //Components
    private HealthComponent Health;


    private void Awake()
    {
        Instance = this;
        currentCam = playerCam;
    }

    private void Start()
    {
        Health = new HealthComponent(GameHealth);
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
        Health.TakeDamage(1);
        uiManager.Health2.text = Health.Health.ToString();
        if (Health.IsDead())
        {
            isGameOver = true;
            audioManager.StopRaid();
            audioManager.GameLose();
            uiManager.canPause = false;
            gameOver.GameEnd();
            
        }
    }

    public void GameWin(bool conquer)
    {
        gameWon = true;
        uiManager.FadeScript.EndingFade();
        audioManager.StopRaid();
        audioManager.GameWin();
        gameWin.GameWon(conquer);
    }

    public void EnableRecipesPart1()
    {
        recipesEnabled = true;
        for (int i = 0; i < recipes.Length; i++)
        {
            recipes[i].SetActive(true);
        }
    }

    public void EnableRecipesPart2()
    {
        recipes2Enabled = true;
        for (int i = 0; i < recipes2.Length; i++)
        {
            recipes2[i].SetActive(true);
        }
    }

    public void SaveGame()
    {
        Save.SaveGame(GameHealth, recipesEnabled, wreckageActive, inLand, recipes2Enabled, gameWon);
    }

    public void LoadGame()
    {
        GameData data = Save.LoadGame();
        GameHealth = data.health;
        recipesEnabled = data.recipes;
        wreckageActive = data.wreckage;
        inLand = data.land;
        uiManager.Health2.text = GameHealth.ToString();
        if (data.won)
        {
            GameWin(true);
        }
        if (GameHealth <= 0)
        {
            gameOver.GameEnd();
        }
        if (data.recipes)
        {
            EnableRecipesPart1();
        }
        if (data.recipes2)
        {
            EnableRecipesPart2();
        }
        if(data.wreckage)
        {
            objectivesManager.ShowWreckage();
        }
    }

}
