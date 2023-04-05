using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Manager")]
    [SerializeField] UIManager uiManager;

    [Header("Save Manager")]
    [SerializeField] SaveManager saveManager;

    [Header("Screens")]
    [SerializeField] GameObject PauseScreen;

    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !uiManager.InventoryOpen && uiManager.canPause)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }    
    }
    public void Resume()
    {
        uiManager.ShowAllCanvas();
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        uiManager.HideAllCanvas();
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Save()
    {
        if (!GameManager.Instance.inRaid)
        {
            saveManager.Save();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
