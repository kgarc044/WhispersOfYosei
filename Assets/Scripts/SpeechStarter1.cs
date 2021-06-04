using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechStarter1 : MonoBehaviour
{
    public GameObject SpeechOverlay;
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && activated == false)
        {
            SpeechOverlay.SetActive(true);
            activated = true;
        }
    }
}
