using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Triggers : MonoBehaviour
{
    [SerializeField] private GameObject _ring;
    [SerializeField] private GameObject _battery;
    private bool _isBattery = false;
    [SerializeField] private List<GameObject> Bears = new List<GameObject>();
    [SerializeField] private GameObject SocketOff;
    [SerializeField] private GameObject SocketOn;
    [SerializeField] private GameObject Cookie;
    [SerializeField] private GameObject CookieOnBed;
    [SerializeField] private GameObject mouses;
    [SerializeField] private List<GameObject> mousesArray = new List<GameObject>();
    [SerializeField] private GameObject Clock;
    [SerializeField] private GameObject Freeze;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown("f"))
        {
            if (other.tag == "BatteryTake" && Bears[1].activeSelf && SocketOff.activeSelf)
            {

                _battery.SetActive(true);
                other.gameObject.GetComponent<AudioSource>().Stop();
                _isBattery = true;
            }

            if (other.tag == "Clock")
            {
                if (_isBattery)
                {
                    _battery.SetActive(false);
                    other.gameObject.GetComponent<AudioSource>().Play();
                    //затемнение
                    Bears[1].SetActive(false);
                    Bears[2].SetActive(true);
                    AudioManager.instance.PlaySound("Bear3");
                    _isBattery = false;
                    Clock.SetActive(false);
                }
            }

            if (other.tag == "Socket")
            {
                SocketOff.SetActive(true);
                SocketOn.SetActive(false);
                Freeze.SetActive(false); 
            }
            
            if (other.tag == "Bed")
            {
                //печенье тру
                //Cookie.SetActive(true);
                CookieOnBed.SetActive(false);
                mouses.SetActive(true);
                mousesArray[0].SetActive(false);
                mousesArray[1].SetActive(false);
                mousesArray[2].SetActive(false);
            }
            
            if (other.tag == "Bear")
            {
                if (mouses.activeSelf)
                {
                    Bears[0].SetActive(false);
                    Bears[1].SetActive(true);
                    AudioManager.instance.PlaySound("Bear1");
                }
            }

            if (other.tag == "Ring")
            {
                _ring.SetActive(true);
                Bears[2].SetActive(false);
                Bears[3].SetActive(true);
                AudioManager.instance.PlaySound("Bear2");
                
            }
        }
        if (other.tag == "Exit" || _ring.activeSelf)
        {
            SceneManager.LoadScene(0);
        }
    }
}
