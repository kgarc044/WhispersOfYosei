using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kami_enemy_mov : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 targetPosition;
    public float speed = 3;
    public bool facingRight = false;
    public int health = 100;
    public float start = 0;
    public float end = 0;
    public float death_time;
    public bool trigger = false;
    Vector3 origin;
    float maxMoveDistance = 10;

    Rigidbody2D rb2d;

    [SerializeField]
    Transform castpoint;

    [SerializeField]
    float agroRange;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (LineofSight(agroRange))
        {
            trigger = true;
        }
        if (trigger == false)
        {
            if (transform.position.x == start)
            {
                if (facingRight == false)
                {
                    Flip();
                }
                targetPosition.x = end;

            }
            else if (transform.position.x == end)
            {
                if (facingRight == true)
                {
                    Flip();
                }

                targetPosition.x = start;

            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else if (trigger == true)
        {
            GetComponent<Animator>().SetBool("DiveBomb", true);
            Destroy(gameObject, death_time);
            divebomb(agroRange);
        }
    }
    void divebomb(float distance)
    {
        var castDist = distance;

        Vector2 endPos = castpoint.position + Vector3.down * castDist;
        transform.position = Vector3.MoveTowards(transform.position,endPos, speed *2* Time.deltaTime);
    }
    bool LineofSight(float distance)
    {
        bool val = false;
        var castDist = distance;

        Vector2 endPos = castpoint.position + Vector3.down * castDist;
        RaycastHit2D hit1 = Physics2D.Linecast(castpoint.position, endPos, 1 << LayerMask.NameToLayer("Player"));

        if (hit1.collider != null)
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

    void Die()
    {
        Destroy(gameObject, death_time);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }

}
