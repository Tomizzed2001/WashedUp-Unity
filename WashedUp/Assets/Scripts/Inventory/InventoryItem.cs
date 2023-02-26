using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Front End
    public Image image;
    public Text stackText;

    //Back End
    public Item item;
    [HideInInspector] public int stackCount = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.icon;
        //stackText.text = stackCount.ToString();
        //UpdateCount();
    }

    public void UpdateCount()
    {
        stackText.text = stackCount.ToString();
    }

    //Begin dragging
    public void OnBeginDrag(PointerEventData eventData)
    {  
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        stackText.raycastTarget = false;
    }

    //Whilst dragging
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    //End drag
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        stackText.raycastTarget = true;
    }
}
