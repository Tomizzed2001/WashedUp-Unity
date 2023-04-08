using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] AudioZone zone;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        zone.switchAudio();
    }
}
