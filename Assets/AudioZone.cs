using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{

    [SerializeField] AudioManager manager;
    [SerializeField] AudioSource audioSource;

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
