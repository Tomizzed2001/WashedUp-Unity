using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int health;
    public bool recipes;
    public bool recipes2;
    public bool wreckage;
    public bool land;
    public bool won;

    public GameData(int gameHealth, bool recipesLearnt, bool wreckageActive, bool inLand, bool recipesSecond, bool gameWon)
    {
        health = gameHealth;
        recipes = recipesLearnt;
        wreckage = wreckageActive;
        land = inLand;
        recipes2 = recipesSecond;
        won = gameWon;
    }
}
