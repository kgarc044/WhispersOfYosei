using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoarMove : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 targetPosition;
    public int speed = 3;
    public bool facingRight = false;
    public int health = 100;
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.x == 3f)
        {
            if(facingRight == false)
            {
                Flip();
            }
            targetPosition.x = -4f;
            
        }
        else if(transform.position.x == -4f)
        {
            if (facingRight == true)
            {
                Flip();
            }

            targetPosition.x = 3f;

        }
        GetComponent<Animator>().SetBool("IsRunning", true);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,speed * Time.deltaTime);
   
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if( health <= 0)
        {
            GetComponent<Animator>().SetBool("boarDeath", true);
            Die();
        }
    }

    void Die()
    {
        
        Destroy(gameObject,1);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }
}
