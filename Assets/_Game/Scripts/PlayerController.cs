using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool _isButtonDown = false;
    private Vector3 _offset;
    private Rigidbody2D _rb;
    public int score;

    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            _isButtonDown = true;
                //_offset = gameObject.transform.position -
                //          Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        }

        if (Input.GetMouseButtonUp(0))
            _isButtonDown = false;
        
        if (_isButtonDown)
        {
            _rb.MovePosition(_rb.position + new Vector2(1f, 0f) * Time.deltaTime);
            //Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
            //transform.position = Camera.main.ScreenToWorldPoint(newPosition);
        }*/
    }
    
    public float distance = 10f;
 
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance); // переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
        transform.position = objPosition; // и собственно объекту записываються координаты
    }

    public void AddCoin(int cout)
    {
        score += cout;
    }
}
