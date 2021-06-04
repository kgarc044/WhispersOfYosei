using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondSpeech : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    [SerializeField] private int index;

    public GameObject continueButton;
    public GameObject shinoImage;
    public GameObject bossImage;
    public GameObject spiritImage;
    public GameObject fireSpiritImage;
    public GameObject secondSpeechOverlay;

    private void Start()
    {
        Time.timeScale = 0.1f;
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
        if (index == 0 || index == 1 || index == 5 ||
            index == 7 || index == 8)
        {
            shinoImage.SetActive(false);
            spiritImage.SetActive(false);
            fireSpiritImage.SetActive(false);
            bossImage.SetActive(true);
        }
        if (index == 2 || index == 10 || index == 15 ||
            index == 17 || index == 19)
        {
            bossImage.SetActive(false);
            spiritImage.SetActive(false);
            fireSpiritImage.SetActive(false);
            shinoImage.SetActive(true);
        }
        if (index == 14)
        {
            bossImage.SetActive(false);
            spiritImage.SetActive(false);
            fireSpiritImage.SetActive(true);
            shinoImage.SetActive(false);
        }
        if (index == 3 || index == 4 || index == 9 || 
            index == 11 || index == 16 || index == 18 ||
            index == 20)
        {
            bossImage.SetActive(false);
            spiritImage.SetActive(true);
            fireSpiritImage.SetActive(false);
            shinoImage.SetActive(false);
        }
        if (index == 6 || index == 12)
        {
            Time.timeScale = 1f;
            secondSpeechOverlay.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        if (index < 20)
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.001f);
            }
        }
        else
        {
            Time.timeScale = 1f;
            secondSpeechOverlay.SetActive(false);
            new WaitForSeconds(0.5f);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            index++;
            textDisplay.text = "";
            continueButton.SetActive(false);
            bossImage.SetActive(false);
            spiritImage.SetActive(false);
            shinoImage.SetActive(false);
        }
    }
}
