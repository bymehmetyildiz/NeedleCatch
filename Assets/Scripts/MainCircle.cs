using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCircle : MonoBehaviour
{
    public GameObject smallCircle;
    public int currentneedle;
    public Text needletext;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            InstantiateSmallCircle();
            currentneedle--;            
        }

        needletext.text = "" + currentneedle;
    }

    void InstantiateSmallCircle()
    {
        Instantiate(smallCircle, transform.position, transform.rotation * Quaternion.Euler(0f, 0f, 180f));
    }
}
