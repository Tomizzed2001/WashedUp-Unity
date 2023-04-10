using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    [Header("Inventory Manager")]
    [SerializeField] InventoryManager inventoryManager;

    [Header("Text field")]
    [SerializeField] Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = inventoryManager.CheckAmmo().ToString();
    }
}
