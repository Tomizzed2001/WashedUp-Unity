using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Fix Boat
public class ObjectiveSeven : Objective
{
    [Header("Objective Specific")]

    [SerializeField] private Boat boat;

    [SerializeField] private Text title;

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        if (boat.boatTier == 1)
        {
            title.text = "Fix the Boat (2/5)";
        }
        else if (boat.boatTier == 2)
        {
            title.text = "Fix the Boat (3/5)";
        }
        else if (boat.boatTier == 3)
        {
            title.text = "Fix the Boat (4/5)";
        }
        else if (boat.boatTier == 4)
        {
            title.text = "Fix the Boat (5/5)";
        }
    }

    private void Update()
    {
        UpdateText();
        if (boat.fixedToday)
        {
            UpdateText();
            ObjectiveComplete();
        }
    }
}
