using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Mouse : MonoBehaviour
{
    [SerializeField]
    private float _walkSpeedX;
    [SerializeField]
    private float _walkSpeedY;
    [SerializeField]
    private float _power = 5f;

    private void Update()
    {
        transform.position += new Vector3(_walkSpeedX * Time.deltaTime, _walkSpeedY * Time.deltaTime, 0f);
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        _walkSpeedX *= -1;
        _walkSpeedY *= -1;
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        StartCoroutine(NoiceCoroutine(col.GetComponent<NoiceMechanics>()));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
    }
    IEnumerator NoiceCoroutine(NoiceMechanics pl=null)
    {
        while(true)
        {
            yield return new WaitForSeconds(0.005f); 
            Debug.Log("123");
            NoiceMechanics.instance.NoiceUp(_power);
        }
    }
    

}

