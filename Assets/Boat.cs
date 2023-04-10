using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    [Header("Sprite Data")]
    [SerializeField] Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    [Header("Boat Data")]
    [SerializeField]
    public bool fixedToday;
    public bool boatFixed;
    public int boatTier = 0;

    [Header("Buttons")]
    [SerializeField] private GameObject sailButton;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void IncreaseTier()
    {
        boatTier++;
        spriteRenderer.sprite = sprites[boatTier];
        if (boatTier == 5)
        {
            boatFixed = true;
            sailButton.SetActive(true);
            GameManager.Instance.objectivesManager.ShowSail();
        }
    }

    public void SaveBoat()
    {
        Save.SaveBoat(boatTier, fixedToday, boatFixed);
    }

    public void LoadBoat()
    {
        BoatData data = Save.LoadBoat();

        boatTier = data.boatTier;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[boatTier];
        fixedToday = data.fixedToday;
        boatFixed = data.boatFixed;
    }
}
