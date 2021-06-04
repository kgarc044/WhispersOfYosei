using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechStarter2 : MonoBehaviour
{
    public GameObject secondSpeechOverlay;
    public GameObject bossHpBar;
    private bool activated = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && activated == false)
        {
            Time.timeScale = 0.1f;
            secondSpeechOverlay.SetActive(true);
            bossHpBar.SetActive(false);
            activated = true;
        }
    }
}
