using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{

    [SerializeField] AudioManager manager;
    [SerializeField] AudioSource audioSource;

    public bool inside;
    private void Start()
    {
        inside = GameManager.Instance.inLand; 
    }

    public void switchAudio()
    {
        if (inside)
        {
            inside = false;
            GameManager.Instance.inLand = inside;
            manager.PlayBeach();
            manager.FadeForest();
        }
        else
        {
            inside = true;
            GameManager.Instance.inLand = inside;
            manager.FadeBeach();
            manager.PlayForest();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.FadeBeach();
        manager.PlayForest();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        manager.PlayBeach();
        manager.FadeForest();
    }
}
