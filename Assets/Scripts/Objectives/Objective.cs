using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Objective : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Managers")]
    [SerializeField] public InventoryManager inventoryManager;

    [Header("Info Fields")]
    [SerializeField] private GameObject info;

    [Header("Objective Settings")]
    [SerializeField]
    public bool objectiveActive;

    public void OnPointerEnter(PointerEventData eventData)
    {
        info.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        info.SetActive(false);
    }

}
