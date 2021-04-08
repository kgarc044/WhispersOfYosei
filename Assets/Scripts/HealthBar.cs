using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider bar;

    public void SetMax(int value){
        bar.maxValue = value;
        bar.value = value;
    }

    public void SetCurrent(int value){
        bar.value = value;
    }
}
