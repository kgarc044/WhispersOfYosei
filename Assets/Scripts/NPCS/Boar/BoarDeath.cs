using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarDeath : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveX;
    public bool isPlayerChecked;
    public Transform PlayerCheck;
    public LayerMask whatisPlayer;
    public float checkRadius = 0.5f;
    public float gameobject_life;

    void Start()
    {
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        checkForPlayer();
    }
    void Update()
    {
        
        if (isPlayerChecked)
        {
            GetComponent<Animator>().SetBool("boarDeath", isPlayerChecked);
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            Destroy(gameObject,gameobject_life);
        }
    }

    void checkForPlayer()
    {
        isPlayerChecked = Physics2D.OverlapCircle(PlayerCheck.position, checkRadius, whatisPlayer);
    }
}
