using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int maxHealth = 10;
    public int maxMana = 10;
    public int currentHealth;
    public int currentMana;
    public HealthBar hp;
    public ManaBar mp;

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
    }

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
//Contact Check
    void OnCollisionEnter2D(Collision2D touch){
        if(touch.collider.CompareTag("Enemy")){
            Damage(1);
        }
    }
}
