using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBoss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar hp;

    public float deathTime = .6f;
    
    public float lineOfSight = 3f;

    public Transform swingPoint;
    public float swingRange = 0.75f;
    public int swingDamage = 60;
    
    public Transform playerPos;
    public LayerMask player;
    public PlayerStat p;

    private WaitForSeconds tick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hp.SetMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, playerPos.position);
        //print("distToPlayer:" + distToPlayer);
        if(dist < lineOfSight)
        {
            Swing();
        }
        else
        {
            GetComponent<Animator>().SetBool("isAtk",false);
        }
    }

    public void TakeDamage(int damage) {
        if (currentHealth - damage > 0){
            currentHealth -= damage;
            if (currentHealth < 50)
            {
                GetComponent<Animator>().SetBool("isSpecial", true);
            }
            hp.SetCurrent(currentHealth);
        } else{
            GetComponent<Animator>().SetBool("isSpecial", false);
            currentHealth = 0;
            hp.SetCurrent(currentHealth);
            Die();
        }
    }

    public void Die(){
        GetComponent<Animator>().SetBool("isDead",true);
        Destroy(gameObject, deathTime);
    }

    public void Swing(){
        GetComponent<Animator>().SetBool("isAtk",true);
        //hitbox detection
        Collider2D[] contact = Physics2D.OverlapCircleAll(swingPoint.position, swingRange, player);
        //Damage
        foreach(Collider2D player in contact){
            p.Damage(swingDamage);
        }
        
    }

    //hitbox visibility
    void OnDrawGizmosSelected(){
        if(swingPoint == null)
            return;
        Gizmos.DrawWireSphere(swingPoint.position, swingRange);
    }

}
