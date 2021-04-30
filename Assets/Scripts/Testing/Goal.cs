using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Transform PlayerCheck;
    public LayerMask whatisPlayer;
    public float checkRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D touch){
        if(touch.collider.CompareTag("Player")){
            Debug.Log("You Win!!!");
        }
    }
}
