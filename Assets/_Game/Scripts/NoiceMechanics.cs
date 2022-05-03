using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NoiceMechanics : MonoBehaviour
{
     
    // HP now
    public NoiceBar test;
    public static NoiceMechanics instance = null;
    public  static NoiceBar noiceBar;

    public GameObject image;
    public GameObject NoRing;
    public GameObject WithRing;
    // Start is called before the first frame update
    void Start()
    {
        noiceBar = test;
        if (instance == null)
        {
            instance = this;
        } else if (instance = this)
        {
            Destroy(gameObject);
        }
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
        if(noiceBar.currectNoice >= 9.8f)
        {EndGame();}
    }
    public void NoiceUp(float power)//дамаг по ушам
    {
        noiceBar.currectNoice += power;
        noiceBar.SetNoice(noiceBar.currectNoice);
    }

    public void EndGame()
    {
        StartCoroutine(End());
    }

    public void Finish(bool ring)
    {
        if(ring)
            NoRing.SetActive(true);
        else
            NoRing.SetActive(true);
    }

    private IEnumerator Finish()
    {
        yield return new WaitForSeconds(2f); 
        SceneManager.LoadScene(0);
    }
    IEnumerator End()
    {
        image.SetActive(true);
        yield return new WaitForSeconds(1.5f); 
        SceneManager.LoadScene(0);
    }
}
