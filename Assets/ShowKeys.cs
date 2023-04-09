using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKeys : MonoBehaviour
{
    [SerializeField] private bool keysShown;
    [SerializeField] private GameObject keys;

    public void toggleKeys()
    {
        keysShown = !keysShown;
        keys.SetActive(keysShown);
    }
}
