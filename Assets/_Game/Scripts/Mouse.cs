using System;
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
    [SerializeField]
    private float _timeRepeat = 0.2f;

    private bool _start = false;

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
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" )
        {
            StopAllCoroutines();
            _start = !_start;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && !_start)
        {
            StartCoroutine(NoiceCoroutine());
            _start = !_start;
        }
    }

    IEnumerator NoiceCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(_timeRepeat); 
            NoiceMechanics.instance.NoiceUp(_power);
        }
    }
    

}

