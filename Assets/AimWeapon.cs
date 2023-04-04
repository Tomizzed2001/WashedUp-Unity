using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    [Header("Cursor Values")]
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot;

    private Camera currentCam;
    private Vector3 mousePos;

    private bool WeaponOut = false;

    private void Start()
    {
        //Centralise the cursor and the crosshair
        hotSpot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
    }

    public void WeaponReady()
    {
        currentCam = GameManager.Instance.currentCam;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        WeaponOut = true;
    }

    public void WeaponAway()
    {
        Cursor.SetCursor(null, Vector2.zero , cursorMode);
        WeaponOut = false;
    }

    private void Update()
    {
        if (WeaponOut)
        {
            mousePos = currentCam.ScreenToWorldPoint(Input.mousePosition);
            //crosshair.transform.position = new Vector2(mousePos.x, mousePos.y);

            Vector3 rotation = mousePos - transform.position;

            float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
