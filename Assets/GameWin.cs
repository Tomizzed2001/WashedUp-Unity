using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    [Header("UI Screens")]
    [SerializeField] private GameObject screenSail;
    [SerializeField] private GameObject screenConquer;

    public void GameWon(bool conquest)
    {
        if (conquest)
        {
            StartCoroutine(ShowMessageConquer());
        }
        StartCoroutine(ShowMessageSail());
    }

    private IEnumerator ShowMessageSail()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0f;
        screenSail.SetActive(true);
    }

    private IEnumerator ShowMessageConquer()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0f;
        screenSail.SetActive(true);
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
