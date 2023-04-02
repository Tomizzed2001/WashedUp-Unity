using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public GameObject Screen;
    [SerializeField] PlayerController player;

    public void BlackOut()
    {
        Screen.SetActive(true);
        player.FreezeMovement();
        Screen.GetComponent<Animation>().Play("FadeOut");
        StartCoroutine(EnableMovement());
    }

    private IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(2.5f);
        player.UnFreezeMovement(2.5f);
    }
}
