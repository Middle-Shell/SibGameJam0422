using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    [SerializeField]
    private float Npower = 5f;
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerController>().NoiceUp(Npower);
            
            Destroy(gameObject);
        }
    }
}
