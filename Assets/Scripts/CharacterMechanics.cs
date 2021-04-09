using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMechanics : MonoBehaviour
{
    public Sprite Fire;
    public Sprite Electric;
    public Sprite Water;
    public Sprite Earth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
    }

    void ChangeSprite()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Water;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Fire;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Electric;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Earth;
        }
    }
}
