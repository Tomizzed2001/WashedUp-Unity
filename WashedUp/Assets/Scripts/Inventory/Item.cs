using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]

public class Item : ScriptableObject
{
    
    public string Name;
    public bool stackable = true;
    public Sprite icon;
    
}

