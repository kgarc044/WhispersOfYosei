using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField]
    private float invincibilityDurationSeconds;
    [SerializeField]
    private float invincibilityDeltaTime;
    public int maxHealth = 100;
    public int maxMana = 10;
    public int currentHealth;
    public int currentMana;
    public int regenRate = 0;
    public HealthBar hp;
    public ManaBar mp;
    public MagicCast magic;
    public AudioSource waterShot;

    private bool isInvincible = false;
    private bool playerDead = false;

    private WaitForSeconds tick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        hp.SetMax(maxHealth);
        mp.SetMax(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDead == true)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Slash)){ //Healing Button for Debugging purposes
            Heal(20);
        }
        if(Input.GetKeyDown(KeyCode.J)){
            Cast(2);
        }
    }
    //Invincible After Taking Damage
    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        GetComponent<Animator>().SetBool("IsHurt", true);
        
        isInvincible = true;
        
        for (float i = 0; i < invincibilityDurationSeconds; i += invincibilityDeltaTime)
        {
            
            // TODO: add any logic we want here
            yield return new WaitForSeconds(invincibilityDeltaTime);
        }

        Debug.Log("Player is no longer invincible!");
        GetComponent<Animator>().SetBool("IsHurt", false);
        isInvincible = false;
    }
    //Invincible After Taking Damage
    /*(void MethodThatTriggersInvulnerability()
    {
        if (!isInvincible)
        {
            StartCoroutine(BecomeTemporarilyInvincible());
        }
    }*/

    //Health System
    public void Damage(int dmg){ //Damage to the player

        //Exit if currently invincible
        if (isInvincible)
        {
            return;
        }
        if (currentHealth > dmg){
            currentHealth -= dmg;
            hp.SetCurrent(currentHealth);

        }else{

            currentHealth = 0;
            hp.SetCurrent(currentHealth);
            GetComponent<Animator>().SetBool("IsDead", true);
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            GameObject.Find("Player").GetComponent<PlayerMove>().enabled = false;
            playerDead = true;

        }
        //Coroutine for invincible
        StartCoroutine(BecomeTemporarilyInvincible());
    }

    void Heal(int heal){
        if(currentHealth + heal < maxHealth){
            currentHealth += heal;
            hp.SetCurrent(currentHealth);
        }else{
            currentHealth = maxHealth;
            hp.SetCurrent(maxHealth);
        }
    }
//Mana System
    void Cast(int cost){
        if(currentMana >= cost){
            currentMana -= cost;
            magic.Shoot();
            waterShot.Play();
            mp.SetCurrent(currentMana);
            if(regen != null){
                StopCoroutine(regen);
            }
            regen = StartCoroutine(Regen());
        }else{
            Debug.Log("Out of Mana\n");
        }
    }

    private IEnumerator Regen(){
        yield return new WaitForSeconds(1);

        while(currentMana < maxMana){
            if(currentMana + regenRate > maxMana){
                currentMana = maxMana;
                mp.SetCurrent(currentMana);
            }else{
                currentMana += regenRate;
                mp.SetCurrent(currentMana);
            }
            yield return tick;
        }
    }
    //Contact Check
    private void OnCollisionStay2D(Collision2D touch)
    {
        if (touch.collider.CompareTag("Enemy"))
        {
            Damage(1);
        }
    }
    void OnCollisionEnter2D(Collision2D touch){
        if (touch.collider.CompareTag("Enemy"))
        {
            Damage(1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            Damage(1);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
        {
            Damage(1);
        }
    }
}
