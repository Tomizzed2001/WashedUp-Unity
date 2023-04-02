using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public GameObject FadeScreen;
    public GameObject StartFade;
    [SerializeField] PlayerController player;

    private void Start()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Playign");
        StartFade.SetActive(true);
        StartFade.GetComponent<Animation>().Play("FadeStart");
        StartCoroutine(HideStart());
    }

    public void BlackOut()
    {
        FadeScreen.SetActive(true);
        player.FreezeMovement();
        FadeScreen.GetComponent<Animation>().Play("FadeOut");
        StartCoroutine(EnableMovement());
    }

    private IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(2.5f);
        player.UnFreezeMovement(2.5f);
    }

    private IEnumerator HideStart()
    {
        yield return new WaitForSeconds(2f);
        StartFade.SetActive(false);
    }
}
