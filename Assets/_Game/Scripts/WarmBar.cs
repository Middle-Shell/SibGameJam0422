using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarmBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(float health)
    {
        
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float health)
    {
        slider.value =health;
        
        fill.color = gradient.Evaluate(slider.value * 0.1f);
    }
    // void Update()
    // {
    //     fill -= Time.deltaTime * 0.1f;
    //     bar.fillAmount = fill;
    // }

    // public void WormRestore()
    // {
    //     fill += Time.deltaTime * 0.1f;
    // }


}
