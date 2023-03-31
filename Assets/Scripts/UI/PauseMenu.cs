using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Manager")]
    [SerializeField] UIManager uiManager;

    [Header("Screens")]
    [SerializeField] GameObject PauseScreen;

    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !uiManager.InventoryOpen)
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
        //Saving initialisation goes here
        return;
    }

    public void Exit()
    {
        Application.Quit();
    }
}