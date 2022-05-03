using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{

     [SerializeField]
    private float _power = 5f;
    [SerializeField]
    

    // Start is called before the first frame update
//  private void OnTriggerEnter2D(Collider2D collision)
//     {
//         if (collision.tag == "Player" )
//         {
//             collision.GetComponent<NoiceMechanics>().NoiceUp(_power);
//         }
//     }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            NoiceMechanics.instance.NoiceUp(_power);
        }
    }



   
}
