using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Slime_Follow_Behavior : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    float Enemy_Jump_Power;

    [SerializeField]
    float Enemy_Attack_Range;

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
    private bool isAgro = false;
    private bool isSearching;
    private float canJump = 2f;

    public bool isgrounded;
    public Transform groundCheck;
    public LayerMask whatisGround;
    public float checkRadius = 0.2f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checkForGround();
        if (LineofSight(agroRange))
        {
            isAgro = true;

        }
        else
        {
            if (isAgro)
            {

                if (!isSearching)
                {
                    isSearching = true;
                    Invoke("StopChasingPlayer", 5);
                    GetComponent<Animator>().SetBool("slimerun", false);
                }

            }

        }
        if (isAgro)
        {

            ChasePlayer();
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
        if (isgrounded && Time.time > canJump)
        {
            rb2d.AddForce(Vector2.up * 1000f);
            canJump = Time.time + 1.5f;
        }
        GetComponent<Animator>().SetBool("slimerun", true);
    }
    void StopChasingPlayer()
    {
        isAgro = false;
        isSearching = false;
        rb2d.velocity = new Vector2(0, 0);
    }
    
    bool LineofSight(float distance)
    {
        bool val = false;
        var castDist = distance;

        if (isFacingleft)
        {
            castDist = -distance;
        }

        Vector2 endPos = castpoint.position + Vector3.right * castDist;
        RaycastHit2D hit1 = Physics2D.Linecast(castpoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

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
    void checkForGround()
    {
        isgrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
    }

}
