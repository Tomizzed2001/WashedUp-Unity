using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [Header("UI Screens")]
    [SerializeField] private GameObject screen;

    public void GameEnd()
    {
        Time.timeScale = 0f;
        screen.SetActive(true);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
