using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Debug.Log("oioi");
        }

    }    
}
