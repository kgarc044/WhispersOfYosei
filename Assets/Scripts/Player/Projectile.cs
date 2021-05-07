using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public float duration = .5f;
    public Rigidbody2D rb;
    public int damage = 40;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        Destroy(gameObject, duration);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        KnightBoss knight = hitInfo.GetComponent<KnightBoss>();
        BoarMove boar = hitInfo.GetComponent<BoarMove>();
        if (boar != null)
        {
            boar.TakeDamage(damage);
        }
        if (knight != null)
        {
            knight.TakeDamage(damage/4);
        }
    }
}
