using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Screens")]
    [SerializeField]
    public GameObject UI;
    public GameObject PauseUI;
    public GameObject FadeUI;

    [Header("UI Scripts")]
    [SerializeField]
    public FadeOut FadeScript;

    [Header("Game variables")]
    [SerializeField]
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
