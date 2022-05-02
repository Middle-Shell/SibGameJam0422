using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePatrol : MonoBehaviour
{

    public float walkSpeed;
    
    public float checkRadius;

    public bool shouldRotate;
    public LayerMask whatIsLayer;

    private Transform target;

    private Rigidbody2D rb;
    private Vector2 move;
    public Vector3 dir;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }



    
  
  

    
  

    
    
    
    

    
}
