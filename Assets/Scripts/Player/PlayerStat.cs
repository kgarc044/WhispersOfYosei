using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStat : MonoBehaviour
{
    public int maxHealth = 10;
    public int maxMana = 10;
    public int currentHealth;
    public int currentMana;
    public int regenRate = 0;
    public HealthBar hp;
    public ManaBar mp;

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
        if(Input.GetKeyDown(KeyCode.Slash)){ //Healing Button for Debugging purposes
            Heal(10);
        }
        if(Input.GetKeyDown(KeyCode.J)){
            Cast(2);
        }
    }
//Health System
    void Damage(int dmg){ //Damage to the player
        if(currentHealth > dmg){
            currentHealth -= dmg;
            hp.SetCurrent(currentHealth);
        }else{
            currentHealth = 0;
            hp.SetCurrent(currentHealth);
        }
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
    void OnCollisionEnter2D(Collision2D touch){
        if(touch.collider.CompareTag("Enemy")){
            Damage(1);
        }
    }
}
