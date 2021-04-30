using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCast : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Shoot();
            
        }
        
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }
}
