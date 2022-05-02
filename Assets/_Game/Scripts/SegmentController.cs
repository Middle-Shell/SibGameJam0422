using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentController : MonoBehaviour
{
    Vector3 prewPos;
    Vector3 prewRot;
    private Rigidbody2D rb;

    public Transform idolTransform; //Идол (с кого копируем)

    void Start(){
        prewPos = idolTransform.position;
        prewRot = idolTransform.rotation.eulerAngles;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        Debug.Log(this.name);
        Vector3 deltaPos = idolTransform.position - prewPos;
        Vector3 deltaRot = (idolTransform.rotation.eulerAngles - prewRot) * Mathf.Deg2Rad;
       
        rb.velocity = deltaPos / Time.deltaTime;
        rb.angularVelocity = deltaRot.z / Time.deltaTime;
       
        prewPos = idolTransform.position;
        prewRot = idolTransform.rotation.eulerAngles;
    }
    /*[SerializeField]
    private float distance = 10f;
    [SerializeField] 
    private float _size;
    [SerializeField]
    private float _speed;
    [SerializeField] 
    private GameObject _forwardSegment;
    [SerializeField] 
    private Rigidbody2D _rb;
    [SerializeField]
    private float _force;
    private float _distanceToPoint;

    public GameObject parentObject;
    public PlayerController playerController;*/

    // Update is called once per frame
    /*void Update()
    {
        
        Vector2 objPosition = new Vector2(_forwardSegment.transform.position.x, _forwardSegment.transform.position.y);
        _distanceToPoint = Vector3.Distance(transform.position, objPosition);
             
        //_rb.MovePosition(objPosition + new Vector2(transform.position.x - objPosition.x, transform.position.y - objPosition.y) * Time.deltaTime);
        //_rb.AddForce(objPosition * _force);
        transform.position = Vector3.MoveTowards(transform.position, objPosition, _distanceToPoint/_speed);
        
        
        Vector3 forwardPosition = _forwardSegment.transform.position;
        forwardPosition.z = (transform.position - Camera.main.transform.position).z;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        forwardPosition.x = forwardPosition.x - objectPos.x;
        forwardPosition.y = forwardPosition.y - objectPos.y;

        float angle = Mathf.Atan2(forwardPosition.y, forwardPosition.x) * Mathf.Rad2Deg ;
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }*/
}
