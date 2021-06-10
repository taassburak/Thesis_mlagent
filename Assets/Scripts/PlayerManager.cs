using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    private float moveTime = 0;
    private bool stop = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     move();   
    }

    void move()
    {   
        
        var playerpos = transform.position;
        playerpos.z = transform.position.z;
        if (!stop)
        {
            moveTime += Time.deltaTime;
            if (moveTime >= 0.05f)
            {
                playerpos.z += 0.2f;
                moveTime = 0;
            }
        
            transform.position = playerpos;
        }
        
        
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "carside")
        {
            stop = true;
        }

        if (other.gameObject.tag == "car")
        {
            SceneManager.LoadScene(0);
        }

        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag =="carside")
        {
            stop = false;
        }
    }
}
