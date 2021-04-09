using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    public GameObject cg;
    public RuntimeAnimatorController FireAttack;
    public RuntimeAnimatorController ElectricAttack;
    public RuntimeAnimatorController WaterAttack;
    public RuntimeAnimatorController EarthAttack;


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
            GetComponent<Animator>().SetBool("IsWaterAttack", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsWaterAttack", false);
        }
        
        if (Input.GetKeyDown(KeyCode.J) && elementCheck == "Fire")
        {
            GetComponent<Animator>().SetBool("IsFireAttack", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsFireAttack", false);
        }
        if (Input.GetKeyDown(KeyCode.J) && elementCheck == "Electric")
        {
            GetComponent<Animator>().SetBool("IsElectricAttack", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsElectricAttack", false);
        }
        if (Input.GetKeyDown(KeyCode.J) && elementCheck == "Earth")
        {
            GetComponent<Animator>().SetBool("IsEarthAttack", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsEarthAttack", false);
        }
    }

    void ChangeSprite()
    { 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cg.gameObject.GetComponent<Animator>().runtimeAnimatorController = WaterAttack;
            elementCheck = "Water";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cg.gameObject.GetComponent<Animator>().runtimeAnimatorController = FireAttack;
            elementCheck = "Fire";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cg.gameObject.GetComponent<Animator>().runtimeAnimatorController = ElectricAttack;
            elementCheck = "Electric";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cg.gameObject.GetComponent<Animator>().runtimeAnimatorController = EarthAttack;
            elementCheck = "Earth";
        }
    }
}
