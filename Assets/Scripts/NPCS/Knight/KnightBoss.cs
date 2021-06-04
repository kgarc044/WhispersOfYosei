using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBoss : MonoBehaviour
{
    #region Public Variables
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar hp;

    public float deathTime = .6f;
    
    public float lineOfSight = 3f;

    public Transform swingPoint;
    public float swingRange = 0.75f;
    public int swingDamage = 60;
    public float swingTime = 1;

    public Transform pillarPoint;
    public float columnRange = 0.3f;
    public int columnDamage = 70;
    public float pillarTime = 1;
    
    public Transform playerPos;
    public LayerMask player;
    public PlayerStat p;
    #endregion
    
    #region Private Variables
    private float timer = 0;
    private bool cooldown = false;
    //private bool near = false;
    private bool attacking = false;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hp.SetMax(maxHealth);
        StartCoroutine(AttackPattern());
    }

    // Update is called once per frame
    void Update()
    {
        checkLOS();
    }
    
    public void Cooldown() {
        cooldown = true;
    }

    private void Wait(float time){
        timer += Time.deltaTime;

        if(timer >= time && cooldown){
            cooldown = false;
            timer = 0;
        }
    }

    private void Halt(){
        Debug.Log("Stopped");
        attacking = false;
        GetComponent<Animator>().SetBool("isAtk", false);
        GetComponent<Animator>().SetBool("isSpecial", false);
    }

    private bool checkLOS() { 
        float dist = Vector2.Distance(transform.position, playerPos.position);
        //print("distToPlayer:" + distToPlayer);
        if (dist < lineOfSight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

//Attack Pattern

    IEnumerator AttackPattern(){
        while(checkLOS() && !attacking){
            Debug.Log("Attack");
            GetComponent<Animator>().SetBool("isAtk", true);
            Debug.Log("Wait");
            yield return new WaitForSeconds(swingTime);
            Debug.Log("Special");
            GetComponent<Animator>().SetBool("isSpecial", true);
            yield return new WaitForSeconds(pillarTime);
        }
    }

    public void TakeDamage(int damage) {
        if (currentHealth - damage > 0){
            currentHealth -= damage;
            
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
        attacking = true;
        //hitbox detection
        Collider2D[] contact = Physics2D.OverlapCircleAll(swingPoint.position, swingRange, player);
        //Damage
        foreach(Collider2D player in contact){
            p.Damage(swingDamage);
        }
        
    }

    public void Special(){
        attacking = true;
        //hitbox detection definitely think there should be a better way to do this buuuut
        Collider2D[] column1 = Physics2D.OverlapBoxAll(pillarPoint.position, new Vector2(columnRange * 2, 1.25f/2), player);
        Collider2D[] column2 = Physics2D.OverlapBoxAll((pillarPoint.position  + new Vector3(-.835f, 0, 0)), new Vector2(columnRange * 2, 1.25f/2), player);
        Collider2D[] column3 = Physics2D.OverlapBoxAll((pillarPoint.position + new Vector3((-1.585f), 0, 0)), new Vector2(columnRange * 2, 1.25f/2), player);
        Collider2D[] column4 = Physics2D.OverlapBoxAll((pillarPoint.position + new Vector3((-2.39f), 0, 0)), new Vector2(columnRange * 2, 1.25f/2), player);
        Collider2D[] column5 = Physics2D.OverlapBoxAll((pillarPoint.position + new Vector3((-3.08f), 0, 0)), new Vector2(columnRange * 2, 1.25f/2), player);
        foreach(Collider2D player in column1){
            p.Damage(columnDamage);
        }
        foreach(Collider2D player in column2){
            p.Damage(columnDamage);
        }
        foreach(Collider2D player in column3){
            p.Damage(columnDamage);
        }
        foreach(Collider2D player in column4){
            p.Damage(columnDamage);
        }
        foreach(Collider2D player in column5){
            p.Damage(columnDamage);
        }
    }

    //hitbox visibility
    void OnDrawGizmosSelected(){
        if(swingPoint == null)
            return;
        Gizmos.DrawWireSphere(swingPoint.position, swingRange);
        if(pillarPoint == null)
            return;
        Gizmos.DrawWireCube(pillarPoint.position, new Vector3(columnRange, 1.25f, 1));
        Gizmos.DrawWireCube((pillarPoint.position + new Vector3(-.835f, 0, 0)), new Vector3(columnRange, 1.25f, 1));
        Gizmos.DrawWireCube((pillarPoint.position + new Vector3((-1.585f), 0, 0)), new Vector3(columnRange, 1.25f, 1));
        Gizmos.DrawWireCube((pillarPoint.position + new Vector3((-2.39f), 0, 0)), new Vector3(columnRange, 1.25f, 1));
        Gizmos.DrawWireCube((pillarPoint.position + new Vector3((-3.08f), 0, 0)), new Vector3(columnRange, 1.25f, 1));
    }

}
