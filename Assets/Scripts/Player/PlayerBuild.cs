using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuild : MonoBehaviour
{
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] GameObject buildRegion;
    [SerializeField] Color red;
    public bool canBuild = true;
    [SerializeField] private Color originalColor;

    private void Start()
    {
        originalColor = buildRegion.GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {
        if (inventoryManager.isSelectedStructure())
        {
            buildRegion.SetActive(true);
            if (!canBuild)
            {
                
                buildRegion.GetComponent<SpriteRenderer>().color = red;
            }
            else
            {
                buildRegion.GetComponent<SpriteRenderer>().color = originalColor;
            }
        }
        else
        {
            buildRegion.SetActive(false);
        }
    }
}
