using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class savePoint : MonoBehaviour
{  
    private PlayerController _player;
     
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("heeeeeey");
        if(collision.tag == "Player")
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
                while(true)
	            {
                pl.WarmHeal(); 
                Debug.Log("123");

                yield return new WaitForSeconds(0.05f); 
                
                }
            }
      private void OnTriggerExit2D(Collider2D collision)
      {
          Debug.Log("321");
         StopAllCoroutines();
      }
    
}
