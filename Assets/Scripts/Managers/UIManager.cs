using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Screens")]
    [SerializeField]
    public GameObject UI;
    public GameObject PauseUI;
    public GameObject FadeUI;
    public GameObject DragUI;

    [Header("UI Scripts")]
    [SerializeField]
    public FadeOut FadeScript;
    public InventoryButton inventoryButton;

    [Header("UI Components")]
    [SerializeField] GameObject CostsTooMuch;
    [SerializeField] public TextMeshProUGUI Health;
    [SerializeField] public Text Health2;

    [Header("Game variables")]
    [SerializeField]
    public bool InventoryOpen = false;
    public bool canPause = true;

    private List<GameObject> UIScreens = new List<GameObject>();

    [Header("Cursor Attributes")]
    [SerializeField] AimWeapon playerCursor;

    private void Start()
    {
        UpdateAllCanvas();
    }

    public void NoResources()
    {
        CostsTooMuch.SetActive(true);
        StartCoroutine(ShowUI(3f, CostsTooMuch));
    }

    private IEnumerator ShowUI(float timeToShow, GameObject uiToShow)
    {
        yield return new WaitForSeconds(timeToShow);
        uiToShow.SetActive(false);
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

    public void ResetCursor()
    {
        playerCursor.WeaponAway();
    }
} 
