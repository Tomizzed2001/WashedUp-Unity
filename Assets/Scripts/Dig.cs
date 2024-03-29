using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : MonoBehaviour
{
    [SerializeField] GameObject chest;
    [SerializeField] GameObject digBox;

    [SerializeField] PlayerController playerController;

    public void DigUpChest()
    {
        StartCoroutine(ShowChest());
        GameManager.Instance.uiManager.FadeScript.BlackOut();
    }

    private IEnumerator ShowChest()
    {
        yield return new WaitForSeconds(2.5f);
        playerController.OnDig();
        chest.SetActive(true);
        digBox.SetActive(false);
        gameObject.SetActive(false);
    }
    // 9.542206, -2.312031
}
