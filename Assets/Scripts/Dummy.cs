using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{

    public int maxHealth = 100;
    public int maxMana = 100;
    public int currentHealth;
    public int currentMana;

    public HealthBar health;
    public ManaBar mana;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentMana = maxMana;
        health.SetMax(maxHealth);
        mana.SetMax(maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backslash)){
            Damage(10);
        }
    }

    void Damage(int dmg){
        currentHealth -= dmg;

        health.SetCurrent(currentHealth);
    }
}
