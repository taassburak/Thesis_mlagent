using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager_Ray : MonoBehaviour
{
    private float moveTime = 0;

    private bool stop;
    // Start is called before the first frame update
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

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            if (hit.collider.tag == "car")
            {
                if (hit.distance < 2)
                {
                    stop = true;
                }
                else
                {
                    stop = false;
                }
            }
            else
            {
                stop = false;
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag== "car")
        {
            SceneManager.LoadScene(0);
        }

        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
    }
}
