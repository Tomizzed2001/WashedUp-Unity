using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixBoat : MonoBehaviour
{
    [Header("Boat to fix")]
    [SerializeField] Boat boat;

    public void fixTheBoat()
    {
        boat.fixedToday = true;
        boat.IncreaseTier();
        gameObject.SetActive(false);
    }

    public void setSail()
    {
        GameManager.Instance.GameWin();
    }
}
