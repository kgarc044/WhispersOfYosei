using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingSpeedtoeitherdirection : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 targetPosition;
    public int speed = 3;
    public bool facingRight = false;
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
            targetPosition.x = 1f;
            
        }
        else if(transform.position.x == 1f)
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
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }
}
