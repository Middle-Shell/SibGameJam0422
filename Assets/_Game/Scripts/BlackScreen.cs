using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public BlackScreen test;
    public static BlackScreen instance = null;
    [SerializeField]
    public Image AImage;
    [SerializeField]
    public  static BlackScreen black;
    [SerializeField]
    public GameObject AlphaObj;
    [SerializeField]
    public bool AlphaA = true;
    // Start is called before the first frame update
    void Start()
    {
        black = test;
        if (instance == null)
        {
            instance = this;
        } else if (instance = this)
        {
            Destroy(gameObject);
        }
    }
        void Update ()
        {
            Blackscreen();
        }
        
    

    public void Blackscreen()
    {
        if(Input.GetKey(KeyCode.A))
        {
        if(AlphaA==true)
        {
            AImage = AlphaObj.GetComponent<Image>();
            AImage.color = new Color (AImage.color.r , AImage.color.b,AImage.color.a*0.5f*Time.deltaTime);
        }
        }
    }

}
