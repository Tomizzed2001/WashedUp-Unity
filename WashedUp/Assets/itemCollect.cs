using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemCollect : MonoBehaviour
{
    [SerializeField] float speed = 4f;
    [SerializeField] float collectionRange = 1.0f;
    [SerializeField] float despawnTime = 10f;

    Transform player;

    private void Awake()
    {
        player = GameManager.Instance.player.transform;   
    }


    private void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime < 0)
        {
            Destroy(gameObject);
        }
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < collectionRange)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if  (distance < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
