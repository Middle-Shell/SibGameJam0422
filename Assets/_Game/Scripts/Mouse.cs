using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Spine.Unity;

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

    [SerializeField] private string _status; //Walking - идёт, EATING - стоит/есть и всё что не двигается
    
    [SerializeField] private List<AudioClip> _clips = new List<AudioClip>();
    public SkeletonAnimation skeletonAnimation;
    [SerializeField]
    private bool move = true;
    [SerializeField]
    private AudioSource _audioSource;
    
    
    private bool _start = false;

    private void Update()
    {
        if (move)
        {
            transform.position += new Vector3(_walkSpeedX * Time.deltaTime, _walkSpeedY * Time.deltaTime, 0f);
            _audioSource.loop = true;
            _audioSource.clip = _clips[1];
            _audioSource.pitch = 1;
            _audioSource.Play();
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        _walkSpeedX *= -1;
        _walkSpeedY *= -1;
        Vector3 scale = transform.localScale;
        transform.localScale = new Vector3(scale.x * -1f, scale.y, scale.z);
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
            if (_status == "Walking")
            {
                skeletonAnimation.AnimationName = "Walking";
            }
            else
            {
                skeletonAnimation.AnimationName = "EATING";
            }
            move = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && !_start)
        {
            skeletonAnimation.AnimationName = "Scream proceed";
            _audioSource.loop = true;
            _audioSource.pitch = 3;
            _audioSource.clip = _clips[0];
            _audioSource.Play();
            StartCoroutine(NoiceCoroutine());
            move = false;
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

