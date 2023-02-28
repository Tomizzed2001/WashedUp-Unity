using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : UseTool
{
    [SerializeField] GameObject drop;
    [SerializeField] int dropNum = 5;
    [SerializeField] float spread = 2f;
    [SerializeField] string Tool;
    [SerializeField] int objectHealth = 3;

    void Shake()
    {
        float posx = gameObject.transform.position.x;
        float posy = gameObject.transform.position.y;
        gameObject.transform.position = new Vector2(posx-0.02f, posy-0.02f);
    }

    public override void Hit()
    {
        string selectedItem = InventoryManager.Instance.getSelectedItemName();
        if ( selectedItem == Tool)
        {
            float posx = gameObject.transform.position.x;
            float posy = gameObject.transform.position.y;
            gameObject.transform.position = new Vector2(posx+0.02f, posy+0.02f);
            Invoke("Shake",0.1f);
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

                Destroy(gameObject);
            }
            
        }
    }
}
