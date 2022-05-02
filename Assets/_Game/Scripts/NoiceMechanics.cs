using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NoiceMechanics : MonoBehaviour
{
     
    // HP now

    public  NoiceBar noiceBar;
    // Start is called before the first frame update
    void Start()
    {
        
        noiceBar.currectNoice = 0f;
        
        noiceBar.SetNoice(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
         NoiceMetr();
    }

    

    void NoiceMetr()//опускает шкалу шума
    {
        if(noiceBar.currectNoice > noiceBar.minNoice) 
        {
            if(noiceBar.currectNoice > noiceBar.maxNoice)
                noiceBar.currectNoice = 10f;
        noiceBar.currectNoice -= Time.deltaTime * 0.5f;
        noiceBar.SetNoice(noiceBar.currectNoice);
        }
    }

    

    

    public  void NoiceUp(float power)//дамаг по ушам
    {
        noiceBar.currectNoice += power;
        noiceBar.SetNoice(noiceBar.currectNoice);
    }
}
