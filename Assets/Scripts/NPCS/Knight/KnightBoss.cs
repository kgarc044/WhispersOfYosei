using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightBoss : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar hp;
    public float death_time = .6f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hp.SetMax(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        if (currentHealth - damage > 0){
            currentHealth -= damage;
            hp.SetCurrent(currentHealth);
        } else{
            currentHealth = 0;
            hp.SetCurrent(currentHealth);
            Die();
        }
    }

    public void Die(){
        GetComponent<Animator>().SetBool("isDead",true);
        Destroy(gameObject, death_time);
    }

}
