using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : UseTool
{
    [SerializeField] GameObject drop;
    [SerializeField] int dropNum = 5;
    [SerializeField] float spread = 2f;


    public override void Hit()
    {

        for (int i = 0; i<dropNum; i++)  // while(dropNum > 0) then decrement dropNum
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
