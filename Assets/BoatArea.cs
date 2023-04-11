using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatArea : MonoBehaviour
{
    [Header("Boat Values")]
    [SerializeField] Boat boat;

    [Header("Button Values")]
    [SerializeField] GameObject FixButton;
    [SerializeField] GameObject SailButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (boat.boatFixed)
        {
            SailButton.SetActive(true);
        }
        if (!boat.fixedToday)
        {
            FixButton.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FixButton.SetActive(false);
        SailButton.SetActive(false);
    }
}
