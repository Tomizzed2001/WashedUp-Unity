using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digbox : MonoBehaviour
{

    [SerializeField] GameObject digButton;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        digButton.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        digButton.SetActive(false);
    }
}
