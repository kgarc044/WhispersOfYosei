using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstSpeech : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    [SerializeField] private int index;

    public GameObject continueButton;
    public GameObject shinoImage;
    public GameObject spiritImage;
    public GameObject firstSpeechOverlay;

    private void Start()
    {
        Time.timeScale = 0.01f;
        StartCoroutine(Type());
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
        if(index == 0 || index == 1 || index == 4 || 
            index == 6 || index == 8 || index == 9 || 
            index == 11 || index == 13)
        {
            shinoImage.SetActive(false);
            spiritImage.SetActive(true);
        }
        if(index == 2 || index == 5 || index == 7 || 
            index == 10 || index == 12)
        {
            spiritImage.SetActive(false);
            shinoImage.SetActive(true);
        }
        if(index == 3 || index > 13)
        {
            spiritImage.SetActive(false);
            shinoImage.SetActive(false);
        }
    }

    IEnumerator Type()
    {
        if (index < 13)
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(0.0001f);
            }
        }
        else
        {
            Time.timeScale = 1f;
            firstSpeechOverlay.SetActive(false);
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if (index < sentences.Length -1)
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
            spiritImage.SetActive(false);
            shinoImage.SetActive(false);
        }
    }
}
