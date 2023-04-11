using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public GameObject FadeScreen;
    public GameObject StartFade;
    public GameObject EndFade;
    [SerializeField] PlayerController player;
    [SerializeField] UIManager uiManager;
    [SerializeField] SaveManager saveManager;
    [SerializeField] GameObject instructions;
    [SerializeField] GameObject saving;

    private void Start()
    {
        Time.timeScale = 1.0f;
        StartFade.SetActive(true);
        StartFade.GetComponent<Animation>().Play("FadeStart");
        StartCoroutine(HideStart());
    }

    public void BlackOut()
    {
        saving.SetActive(true);
        saveManager.Save();
        uiManager.canPause = false;
        FadeScreen.SetActive(true);
        player.FreezeMovement();
        FadeScreen.GetComponent<Animation>().Play("FadeOut");
        StartCoroutine(EnableMovement());
    }

    public void ForceBlackOut()
    {
        saving.SetActive(false);
        uiManager.canPause = false;
        FadeScreen.SetActive(true);
        player.FreezeMovement();
        FadeScreen.GetComponent<Animation>().Play("FadeOut");
        StartCoroutine(EnableMovement());
    }

    public void EndingFade()
    {
        uiManager.canPause = false;
        EndFade.SetActive(true);
        EndFade.GetComponent<Animation>().Play("FadeEnd");
    }

    private IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(2.5f);
        uiManager.canPause = true;
        player.UnFreezeMovement(2.5f);
    }

    private IEnumerator HideStart()
    {
        yield return new WaitForSeconds(2f);
        StartFade.SetActive(false);
        instructions.SetActive(true);

    }
}
