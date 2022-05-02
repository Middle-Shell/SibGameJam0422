using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    public float power  =5f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("heeeeeey");
        if(collision.tag == "Player")
        {   
            
            // _player = GetComponent<PlayerController>();

            //InvokeRepeating("WarmHeal",1f,0.3f);
           StartCoroutine(NoiceCoroutine(collision.GetComponent<NoiceMechanics>()));
            //Debug.Log("asdf");
            //collision.GetComponent<PlayerController>().WarmHeal();
        }
    }

        IEnumerator NoiceCoroutine(NoiceMechanics pl=null)
            {
                while(true)
	            {
                pl.NoiceUp(power); 
                Debug.Log("123");

                yield return new WaitForSeconds(0.005f); 
                
                }
            }

    private void OnTriggerExit2D(Collider2D collision)
      {
          
         StopAllCoroutines();
      }

}

