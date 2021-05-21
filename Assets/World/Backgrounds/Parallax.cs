using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform subject;
    [SerializeField] float fire = 0F;

    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;

    float distanceFromSubject => transform.position.z - subject.position.z;
    float clippingPlane => (cam.transform.position.z + 
        (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    public void Update()
    {
        if (transform.CompareTag("Ground"))
        {
            fire = 1 - (float)(subject.position.x / 70);
            GetComponent<Tilemap>().color = new Color(1, fire, fire, 1);
        }
        else
        {
            Vector2 newPos = startPosition + travel * parallaxFactor;
            transform.position = new Vector3(newPos.x, newPos.y, startZ);
        }
        if (transform.CompareTag("BackgroundFire"))
        {
            fire = 1 - (float)(subject.position.x / 25);
            GetComponent<SpriteRenderer>().color = new Color(1, fire, fire, 1);
        }
        if (transform.CompareTag("BackgroundFire1"))
        {
            fire = 1 - (float)(subject.position.x / 30);
            GetComponent<SpriteRenderer>().color = new Color(1, fire, fire, 1);
        }
        if (transform.CompareTag("BackgroundFire2"))
        {
            fire = 1 - (float)(subject.position.x / 35);
            GetComponent<SpriteRenderer>().color = new Color(1, fire, fire, 1);
        }
        if (transform.CompareTag("BackgroundFire3"))
        {
            fire = 1 - (float)(subject.position.x / 50);
            GetComponent<SpriteRenderer>().color = new Color(1, fire, fire, 1);
        }
    }

}
