using UnityEngine;

public class Breakable : UseTool
{
    public bool isbroken;

    [Header("Object Settings")]
    [SerializeField] int originalHealth = 3;
    [SerializeField] string Tool;
    [SerializeField] string objectType;
    [SerializeField] bool needsTool;

    [Header("Spawn Settings")]
    public int DayToSpawn = 1;
    public bool canRespawn;
    public float respawnChance;

    [Header("Drop Settings")]
    [SerializeField] float spread = 2f;
    [SerializeField] GameObject[] drops;
    [SerializeField] int[] dropRateLower;
    [SerializeField] int[] dropRateUpper;

    //Components
    private HealthComponent Health;

    private void Awake()
    {
        Health = new HealthComponent(originalHealth);
    }

    public void ResetHealth()
    {
        Health = new HealthComponent(originalHealth);
    }

    void Shake()
    {
        float posx = gameObject.transform.position.x;
        float posy = gameObject.transform.position.y;
        gameObject.transform.position = new Vector2(posx-0.02f, posy-0.02f);
    }

    public override void Hit()
    {
        string selectedItem = InventoryManager.Instance.getSelectedItemName();
        if ( selectedItem == Tool || !needsTool)
        {
            float posx = gameObject.transform.position.x;
            float posy = gameObject.transform.position.y;

            //Make the object shake upon interaction
            gameObject.transform.position = new Vector2(posx+0.02f, posy+0.02f);
            Invoke("Shake",0.1f);
            
            //Play sounds depending on object
            if (objectType == "Tree")
            {
                GameManager.Instance.audioManager.TreeChop();
            }
            else if (objectType == "Rock") {
                GameManager.Instance.audioManager.StoneHit();
            }
            else if (objectType == "Barrel")
            {
                GameManager.Instance.audioManager.BarrelHit();
            }

            //Change object health and destroy at 0
            Health.TakeDamage(1);
            if (Health.IsDead())
            {
                if (objectType == "collectable")
                {
                    GameManager.Instance.audioManager.Pop();
                }
                for (int i = 0; i < drops.Length; i++)
                {
                    int dropNum = Random.Range(dropRateLower[i], dropRateUpper[i]+1);
                    for (int j = 0; j < dropNum; j++)
                    {
                        Vector3 pos = transform.position;
                        pos.x += spread * Random.value - spread / 2;
                        pos.y += spread * Random.value - spread / 2;

                        GameObject droppable = Instantiate(drops[i]);
                        droppable.transform.position = pos;
                    }
                }
                isbroken = true;
                gameObject.SetActive(false);
            }
            
        }
    }
}
