using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator myAnimation;
    public int playerSpeed = 15;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isgrounded;
    public Transform groundCheck;
    public LayerMask whatisGround;
    public float checkRadius = 0.2f;
    public bool FacingRight = true;
    //public bool onGround;
    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        PMove();
        checkForGround();
    }
    // Update is called once per frame
    void Update()
    {
        //GetComponent<Animator>().SetBool("Grounded", isgrounded);
        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            Jump();
        }
       
    }

    void PMove()
    {
        //Controls
        moveX = Input.GetAxis("Horizontal");
  
        
        if(moveX != 0)
        {
            
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        
        if (moveX < 0.0f && FacingRight)
        {
            if (!this.myAnimation.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                FacingRight = !FacingRight;
                transform.Rotate(0f, 180f, 0f);
            }
        }
        if (moveX > 0.0f && !FacingRight)
        {
            if (!this.myAnimation.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
                FacingRight = !FacingRight;
                transform.Rotate(0f, 180f, 0f);
            }
        }
        if (!this.myAnimation.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void Jump()
    {
        //Jumping Code
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, playerJumpPower));
    }
    void checkForGround()
    {
        isgrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);
    }
}
