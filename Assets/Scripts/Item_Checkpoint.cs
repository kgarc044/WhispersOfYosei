using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Checkpoint : MonoBehaviour
{
    private Master_Checkpoint cm;

    private void Start()
    {
        cm = GameObject.FindGameObjectWithTag("CM").GetComponent<Master_Checkpoint>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cm.lastCheckPointPos = transform.position;
            GetComponent<Animator>().SetBool("hit", true);
        }
    }
}
