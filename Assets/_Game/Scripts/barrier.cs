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
            NoiceMechanics.instance.NoiceUp(Npower);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
           
    
        if(collision.gameObject.tag == "Player" )
        {
            NoiceMechanics.instance.NoiceUp(Npower);
            
            
        }
    
}
}
    

