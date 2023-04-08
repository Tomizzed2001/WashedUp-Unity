using UnityEngine;

public class Breakable : UseTool
{
    public bool isbroken;

    [Header("Object Settings")]
    [SerializeField] int objectHealth = 3;
    [SerializeField] float spread = 2f;
    [SerializeField] string Tool;
    [SerializeField] string objectType;
    public int DayToSpawn = 1;
    [SerializeField] bool needsTool;

    [Header("Drop Settings")]
    [SerializeField] GameObject[] drops;
    [SerializeField] int[] dropRateLower;
    [SerializeField] int[] dropRateUpper;


    private int originalHealth;

    private void Start()
    {
        originalHealth = objectHealth;
    }

    public void resetHealth()
    {
        objectHealth = originalHealth;
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
            
            //Change object health and destroy and 0
            objectHealth -= 1;
            if (objectHealth == 0)
            {
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
