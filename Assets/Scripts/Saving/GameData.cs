using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int health;
    public bool recipes;
    public bool wreckage;

    public GameData(int gameHealth, bool recipesLearnt, bool wreckageActive)
    {
        health = gameHealth;
        recipes = recipesLearnt;
        wreckage = wreckageActive;
    }
}
