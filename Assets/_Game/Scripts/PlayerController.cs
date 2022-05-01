using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float distance = 10f;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private bool _isButtonDown = false;
    public bool hot = false;
    private Vector3 _offset;
    private float _distanceToPoint;
    public int score;
    public float maxHealth = 10f,minNoice = 0f,maxNoice=10f;
    public float currectHealth,currectNoice;

    public WarmBar warmBar; 
    public NoiceBar noiceBar;

    private void Start()// maxHp set
    {
        currectHealth = maxHealth;
        currectNoice = 5f;
        warmBar.SetMaxHealth(maxHealth);
        noiceBar.SetNoice(5f);
    }
    private void Update()
    {
         if (Input.GetMouseButtonDown(0))
         {
             _isButtonDown = true;
         }

         if (Input.GetMouseButtonUp(0))
             _isButtonDown = false;
         
         if (_isButtonDown)
         {
             Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); 
             Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
             _distanceToPoint = Vector3.Distance(transform.position, objPosition);
             
             transform.position = Vector3.MoveTowards(transform.position, objPosition, _distanceToPoint/_speed);
         }
         Freeze();
         NoiceMetr();
         

         
    }
    public void AddCoin(int cout)//($_$)
    {
        score+=cout;

    }

    void NoiceMetr()//опускает шкалу шума
    {
        if(currectNoice > minNoice) 
        {
            if(currectNoice > maxNoice)
                currectNoice = 10f;
        currectNoice -= Time.deltaTime * 0.5f;
        noiceBar.SetNoice(currectNoice);
        }
    }

    void Freeze()//постоянный урон
    {   
        
        currectHealth -= Time.deltaTime * 0.5f;
        warmBar.SetHealth(currectHealth);
    
    }

    public void WarmHeal() // хил 
    {  
        if(currectHealth<maxHealth)
        {
        currectHealth +=  0.1f;
        warmBar.SetHealth(currectHealth);
        }
    }

    public void NoiceUp(float power)//дамаг по ушам
    {
        currectNoice += power;
        noiceBar.SetNoice(currectNoice);
    }

     
    
}
