using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Explore
public class ObjectiveEight : Objective
{
    [SerializeField] ChestManager chestManager;

    private void Update()
    {
        if (chestManager.wreckageOneChest.chestOpen)
        {
            GameManager.Instance.EnableRecipes();
            ObjectiveComplete();
        }
    }
}
