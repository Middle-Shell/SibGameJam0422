using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {   
            Debug.Log("cold");
            collision.GetComponent<PlayerController>().ColdDeath();
        }
    }
}
