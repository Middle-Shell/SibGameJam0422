using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float distance = 10f;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private bool _isButtonDown = false;
    
    [SerializeField]
    private AudioSource _audioSource;
    
    private Vector3 _offset;
    private float _distanceToPoint;
   
    [SerializeField]    
    List<GameObject> parts = new List<GameObject>();
    [SerializeField] 
    private List<Transform> targets = new List<Transform>();

    public float coof = 1;

    float currentRotation = 0.0f;
    public WarmBar warmBar; 
    
    public int score;
    public float maxHealth = 10f; // min max
    public float currectHealth;

    
//_______________________________________________________________________________________________________________________________________________________

    


    
    
    private Vector2 velocity;
    [SerializeField] 
    private Rigidbody2D rb2D;
    private void Start()// maxHp set
    {
       currectHealth = maxHealth;
       warmBar.SetHealth(maxHealth);
     //  AudioManager.instance.PlayMusic();
	
    }
    private void Update()
    {
        
         if (Input.GetMouseButtonDown(0))
         {
             _isButtonDown = true;
             _audioSource.Play();
         }

         if (Input.GetMouseButtonUp(0))
             _isButtonDown = false;
         
         if (_isButtonDown)
         {
             
             //move
             Vector3 mousePosition = Input.mousePosition; 
             
             Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
             _distanceToPoint = Vector3.Distance(transform.position, objPosition);
             
             velocity = new Vector2((objPosition.x-transform.position.x>0?1f:-1f)*_distanceToPoint/_speed, (objPosition.y-transform.position.y>0?1f:-1f)*_distanceToPoint/_speed);
             rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
             
             //rotation
             Vector3 mousePos = Input.mousePosition;
             mousePos.z = (transform.position - Camera.main.transform.position).z;

             Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
             mousePos.x = mousePos.x - objectPos.x;
             mousePos.y = mousePos.y - objectPos.y;

             float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
        
             transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
         }
         else
         {
             _audioSource.Stop();
         }
         Freeze();
         

         
    }

    

    public void AddCoin(int cout)
    {
        score+=cout;

    }
    public void ColdDeath()
    {
        currectHealth -= 0.3f;
        warmBar.SetHealth(currectHealth);
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
        currectHealth +=  0.03f;
        warmBar.SetHealth(currectHealth);
        }
    }

     
    
}
