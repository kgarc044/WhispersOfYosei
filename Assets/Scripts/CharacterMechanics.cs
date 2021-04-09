using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    public GameObject cg;
    //public RuntimeAnimatorController Fire;
    //public RuntimeAnimatorController Electric;
    //public RuntimeAnimatorController Water;
    //public RuntimeAnimatorController Earth;

    //public RuntimeAnimatorController FireAttack;
    //public RuntimeAnimatorController ElectricAttack;
    public RuntimeAnimatorController WaterAttack;
    //public RuntimeAnimatorController EarthAttack;


    string elementCheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //cg.gameObject.AddComponent<Animator>();
        ChangeSprite();
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J) && elementCheck == "Water")
        {
            GetComponent<Animator>().SetBool("IsAttack", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsAttack", false);
        }
        /*
        if (Input.GetKeyDown(KeyCode.J) && elementCheck == "Fire")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = FireAttack;
        }
        if (Input.GetKeyDown(KeyCode.J) && elementCheck == "Electric")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ElectricAttack;
        }
        if (Input.GetKeyDown(KeyCode.J) && elementCheck == "Earth")
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = EarthAttack;
        }*/
    }
    void ChangeSprite()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cg.gameObject.GetComponent<Animator>().runtimeAnimatorController = WaterAttack;
            elementCheck = "Water";
        }
        /*if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Fire;
            elementCheck = "Fire";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Electric;
            elementCheck = "Electric";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Earth;
            elementCheck = "Earth";
        }*/
    }
}
