using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]

public class Item : ScriptableObject
{
    [Header("Item Identity")]
    public string Name;    
    public Sprite icon;

    [Header("Item Attributes")]
    public bool stackable = true;
    public bool isTool;
    public bool isStructure;
    
}

