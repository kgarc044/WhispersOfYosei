using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private Transform playerTransform;

    public float distance;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) > 2)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, 100);
        }
        if (Vector2.Distance(transform.position, playerTransform.position) > distance)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }
        if (transform.position.x < playerTransform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
        if(transform.position.x > playerTransform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }
}
