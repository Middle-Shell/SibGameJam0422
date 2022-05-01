using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarmBar : MonoBehaviour
{
    public Image bar;
    public float fill = 1f;
    public Gradient gradient;

    void Update()
    {
        fill -= Time.deltaTime * 0.1f;
        bar.fillAmount = fill;
    }

    public void WormRestore()
    {
        fill += Time.deltaTime * 0.1f;
    }


}
