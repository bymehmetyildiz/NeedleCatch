using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SmallCircle : MonoBehaviour
{
    Rigidbody2D physics;
    public float speed;
    bool movecontrol = false;
    GameObject gameControl;
    
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        gameControl = GameObject.FindGameObjectWithTag("GameControl");
    }


    void FixedUpdate()
    {
        if (!movecontrol)
        {
            physics.MovePosition(physics.position + Vector2.up * speed * Time.deltaTime);
           
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Circle")
        {
            transform.SetParent(collision.transform);
            movecontrol= true;
        }

        if(collision.tag == "Needle")
        {
            gameControl.GetComponent<GameControl>().GameOver();
        }
    }
}
