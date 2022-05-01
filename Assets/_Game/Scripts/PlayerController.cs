using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float distance = 10f;
    [SerializeField]
    private bool _isButtonDown = false;
    private Vector3 _offset;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
         if (Input.GetMouseButtonDown(0))
         {
             _isButtonDown = true;
                 //_offset = gameObject.transform.position -
                 //          Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
         }

         if (Input.GetMouseButtonUp(0))
             _isButtonDown = false;
         
         if (_isButtonDown)
         {
             //_rb.MovePosition(_rb.position + new Vector2(1f, 0f) * Time.deltaTime);
             Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); 
             Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); 
             transform.position = objPosition; 
             //Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
             //transform.position = Camera.main.ScreenToWorldPoint(newPosition);
         }
    }
    
}
