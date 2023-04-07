using UnityEngine;

public class Breakable : UseTool
{
    public bool isbroken;

    [Header("Object Settings")]
    [SerializeField] int objectHealth = 3;
    [SerializeField] int dropNum = 5;
    [SerializeField] float spread = 2f;
    [SerializeField] bool needsTool;
    [SerializeField] string Tool;
    [SerializeField] GameObject drop;
    [SerializeField] string objectType;
    public int DayToSpawn = 1;

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
            gameObject.transform.position = new Vector2(posx+0.02f, posy+0.02f);
            Invoke("Shake",0.1f);
            
            if (objectType == "Tree")
            {
                GameManager.Instance.audioManager.TreeChop();
            }
            else if (objectType == "Rock") {
                GameManager.Instance.audioManager.StoneHit();
            }
            
            objectHealth -= 1;
            if (objectHealth == 0)
            {
                for (int i = 0; i < dropNum; i++)  // while(dropNum > 0) then decrement dropNum
                {
                    Vector3 pos = transform.position;
                    pos.x += spread * UnityEngine.Random.value - spread / 2;
                    pos.y += spread * UnityEngine.Random.value - spread / 2;
                    GameObject go = Instantiate(drop);
                    go.transform.position = pos;

                }
                isbroken = true;
                gameObject.SetActive(false);
            }
            
        }
    }
}
