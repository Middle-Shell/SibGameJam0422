using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class savePoint : MonoBehaviour
{  
    private PlayerController _player;
    private bool fPress,savePointCh=false;

     
    //  void Update()
    //  {
    //      if(Input.GetKeyDown("f"))
    //         { savePointCh = !savePointCh;}
    //     if(savePointCh==false)
    //         {StopAllCoroutines();}
    //  }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("heeeeeey");
        StopCoroutine(HealCoroutine());
        if(collision.tag == "Player") //&& savePointCh==true)
        {   
            
            // _player = GetComponent<PlayerController>();
            
            //InvokeRepeating("WarmHeal",1f,0.3f);
            
            
           StartCoroutine(HealCoroutine(collision.GetComponent<PlayerController>()));
           
            
            //Debug.Log("asdf");
            //collision.GetComponent<PlayerController>().WarmHeal();
        }
    }
   
    IEnumerator HealCoroutine(PlayerController pl=null)
            {
                
                
                pl.WarmHeal(); 
                yield return new WaitForSeconds(0.5f); 
                
                
                
            }
      private void OnTriggerExit2D(Collider2D collision)
      {
         
         StopAllCoroutines();
      }


    
}
