using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiceBar : MonoBehaviour
{
    public float minNoice = 0f,maxNoice=10f; // min max
     public float currectNoice;
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxNoice(float noice)
    {
        
        slider.maxValue = noice;
        slider.value = noice;
        //fill.color = gradient.Evaluate(1f);
    }
    public void SetNoice(float noice)
    {
        
        slider.value = noice;
        
        //fill.color = gradient.Evaluate(slider.value);
    }
}
