using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    [SerializeField]
    private float Npower = 0.1f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "segment" || collision.gameObject.tag == "Player")
        {
            AudioManager.instance.PlaySound("Col" + Random.Range(1, 5));
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
    

