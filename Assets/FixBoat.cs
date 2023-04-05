using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixBoat : MonoBehaviour
{
    [Header("Boat to fix")]
    [SerializeField] Boat boat;

    [Header("Managers")]
    [SerializeField] UIManager uiManager;

    public void fixTheBoat()
    {
        StartCoroutine(TriggerBuild());
    }

    public void setSail()
    {
        GameManager.Instance.GameWin();
    }

    private IEnumerator TriggerBuild()
    {
        uiManager.FadeScript.BlackOut();
        yield return new WaitForSeconds(2.5f);
        boat.fixedToday = true;
        boat.IncreaseTier();
        gameObject.SetActive(false);
    }
}
