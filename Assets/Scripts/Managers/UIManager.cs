using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Screens")]
    public GameObject UI;
    public GameObject PauseUI;

    [Header("Game variables")]
    public bool InventoryOpen = false;

    private List<GameObject> UIScreens = new List<GameObject>();

    private void Start()
    {
        UpdateAllCanvas();
    }

    private void UpdateAllCanvas()
    {
        UIScreens.Clear();
        foreach (var gameObj in GameObject.FindGameObjectsWithTag("UICanvas"))
        {
            UIScreens.Add(gameObj);
        }
    }

    public void HideAllCanvas()
    {
        UpdateAllCanvas();
        foreach (var gameObj in UIScreens)
        {
            gameObj.SetActive(false);
        }
    }

    public void ShowAllCanvas()
    {
        foreach (var gameObj in UIScreens)
        {
            gameObj.SetActive(true);
        }
    }
} 
