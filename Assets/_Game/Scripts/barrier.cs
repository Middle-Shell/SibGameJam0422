using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    [SerializeField]
    private float Npower = 1f;
        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "segment")
        {
            collision.gameObject.GetComponent<NoiceMechanics>().NoiceUp(Npower);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
           
    
        if(collision.gameObject.tag == "Player" )
        {
            collision.gameObject.GetComponent<NoiceMechanics>().NoiceUp(Npower);
            
            
        }
    
}
}
    

