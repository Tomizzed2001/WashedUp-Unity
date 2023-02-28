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
    public RectTransform rectTransform;

    //Back End
    public Item item;
    [HideInInspector] public int stackCount = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.icon;
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
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
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
        rectTransform.localScale = new Vector3(1f, 1f, 1f);
        image.raycastTarget = true;
        stackText.raycastTarget = true;
    }
}
