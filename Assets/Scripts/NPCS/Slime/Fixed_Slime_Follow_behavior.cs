using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Fixed_Slime_Follow_behavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform player;

    [SerializeField]
    float agrorange;
    
    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    public int health;
    public float death_time;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distToPlayer:" + distToPlayer);
        if(distToPlayer < agrorange)
        {
            GetComponent<Animator>().SetBool("slimerun", true);
            ChasePlayer();
        }
        else
        {
            //stopchasing player
            StopChasingPlayer();
        }
    }

    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);

        }
        else if(transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }
    private void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
        GetComponent<Animator>().SetBool("slimerun", false);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<Animator>().SetBool("slimeDeath", true);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject, death_time);
    }

}
