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
            Destroy(gameObject,1);
        }
    }

    void checkForPlayer()
    {
        isPlayerChecked = Physics2D.OverlapCircle(PlayerCheck.position, checkRadius, whatisPlayer);
    }
}
