using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public RectTransform rectTransform;
    //public Color selectedColor;
    //public Color originalColor;

    private void Awake()
    {
        UnSelect();
    }

    public void Select()
    {
        //image.color = selectedColor;
        rectTransform.localScale = new Vector3(1.4f, 1.4f, 1f);
        
    }

    public void UnSelect()
    {
        rectTransform.localScale = new Vector3(1.2f, 1.2f, 1f);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        { 
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryItem = dropped.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }

}
