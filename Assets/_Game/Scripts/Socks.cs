using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socks : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {   
            
            // _player = GetComponent<PlayerController>();
            
            //InvokeRepeating("WarmHeal",1f,0.3f);
            
            
        collision.GetComponent<PlayerController>().WarmHeal();
           
            
            //Debug.Log("asdf");
            //collision.GetComponent<PlayerController>().WarmHeal();
        }
    }
}
