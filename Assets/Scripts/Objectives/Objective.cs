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
    [SerializeField] private GameObject strike;

    [Header("Objective Settings")]
    [SerializeField]
    public bool objectiveActive;

    public bool objectiveDone = false;

    private void Start()
    {
    }

    public void ObjectiveComplete()
    {
        if (!objectiveDone)
        {
            objectiveDone = true;
            GameManager.Instance.audioManager.Objecive();
        }
        StartCoroutine(RemoveObjective());
    }

    private void FixedUpdate()
    {
        if (objectiveDone)
        {
            StartCoroutine(RemoveObjective());
        }
    }

    private IEnumerator RemoveObjective()
    {
        strike.SetActive(true);
        yield return new WaitForSeconds(1f);
        objectiveActive = false;
        info.SetActive(false);
        strike.SetActive(false);
        gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        info.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        info.SetActive(false);
    }

}
