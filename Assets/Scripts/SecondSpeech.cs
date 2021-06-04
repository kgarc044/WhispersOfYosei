using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondSpeech : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    [SerializeField] private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject shinoImage;
    public GameObject bossImage;
    public GameObject spiritImage;
    public GameObject secondSpeechOverlay;

    private void Start()
    {
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
        if (index == 0 || index == 1 || index == 5)
        {
            shinoImage.SetActive(false);
            spiritImage.SetActive(false);
            bossImage.SetActive(true);
        }
        if (index == 2)
        {
            bossImage.SetActive(false);
            spiritImage.SetActive(false);
            shinoImage.SetActive(true);
        }
        if (index == 3 || index == 4)
        {
            bossImage.SetActive(false);
            spiritImage.SetActive(true);
            shinoImage.SetActive(false);
        }
        if (index > 6)
        {
            bossImage.SetActive(false);
            spiritImage.SetActive(false);
            shinoImage.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        if (index < 5)
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.02f);
            }
        }
        else
        {
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
