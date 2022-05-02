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
             Vector3 mousePosition = Input.mousePosition; 
             
             Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
             _distanceToPoint = Vector3.Distance(transform.position, objPosition);
             
             velocity = new Vector2((objPosition.x-transform.position.x>0?1f:-1f)*_distanceToPoint/_speed, (objPosition.y-transform.position.y>0?1f:-1f)*_distanceToPoint/_speed);
            //  Debug.Log(objPosition.x);
            //  Debug.Log(transform.position.x);
            //  Debug.Log(objPosition.x-transform.position.x);
             rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
             
             Vector3 mousePos = Input.mousePosition;
             mousePos.z = (transform.position - Camera.main.transform.position).z;

             Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
             mousePos.x = mousePos.x - objectPos.x;
             mousePos.y = mousePos.y - objectPos.y;

             float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
        
             transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
             /*//move
             Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); 
             Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
             _distanceToPoint = Vector3.Distance(transform.position, objPosition);
             
             transform.position = Vector3.MoveTowards(transform.position, objPosition, _distanceToPoint/_speed);
             
             //rotation
             Vector3 mousePos = Input.mousePosition;
             mousePos.z = (transform.position - Camera.main.transform.position).z;

             Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
             mousePos.x = mousePos.x - objectPos.x;
             mousePos.y = mousePos.y - objectPos.y;

             float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
        
             transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
             StartCoroutine(MoveParts());
             */

         }
         Freeze();
         

         
    }

    IEnumerator MoveParts()
    {yield return new WaitForSeconds(.05f);
        // Vector3 oldPosition = transform.position;
        // var oldRotation = transform.rotation;
        // float distanceToTarget;
        // //Vector2 velocity;
        //
        // foreach (var item in Enumerable.Range(0, Math.Min(targets.Count, parts.Count)).Select(x => new { Target = targets[x], Part = parts[x] }))
        // {
        //     distanceToTarget = Vector3.Distance(item.Part.transform.position, item.Target.position);
        //     /*velocity = new Vector2((item.Part.transform.position.x - item.Target.position.x / _speed) * coof, (item.Part.transform.position.y - item.Target.position.y / _speed) * coof);
        //     item.Part.GetComponent<Rigidbody2D>().MovePosition((Vector2)item.Part.transform.position + velocity * Time.fixedDeltaTime);*/
        //     
        //     Vector3 currentPos = item.Target.transform.position;
        //     
        //     var currentRot = item.Part.transform.rotation;
        //     item.Part.transform.position = Vector3.MoveTowards(item.Part.transform.position, item.Target.transform.position, (distanceToTarget/_speed)*coof);
        //     item.Part.transform.rotation = oldRotation;
        //     oldPosition = currentPos;
        //     oldRotation = currentRot;
        //     yield return new WaitForSeconds(.05f);
        // }
    }
    public void AddCoin(int cout)
    {
        score+=cout;

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
