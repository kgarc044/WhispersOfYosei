using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Slime_Follow_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform castpoint;

    [SerializeField]
    Transform player;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float agroRange;

    Rigidbody2D rb2d;

    bool isFacingleft;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
 

    // Update is called once per frame
    void Update()
    {
        if (LineofSight(agroRange))
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
        
    }
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
            isFacingleft = false;
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
            isFacingleft = true;
        }
        
    }
    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
    
    bool LineofSight(float distance)
    {
        bool val = false;
        var castDist = -distance;

        if (isFacingleft)
        {
            castDist = -distance;
        }

        Vector2 endPos = castpoint.position + Vector3.right * distance;
        RaycastHit2D hit1 = Physics2D.Linecast(castpoint.position, endPos, 1 << LayerMask.NameToLayer("Player"));

        if(hit1.collider != null)
        {
            if (hit1.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
            Debug.DrawLine(castpoint.position, hit1.point, Color.yellow);
        }
        else
        {
            Debug.DrawLine(castpoint.position, endPos, Color.blue);
        }
        return val;
    }
   
}
