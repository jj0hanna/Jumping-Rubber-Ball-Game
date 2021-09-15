using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Player : MonoBehaviour
{
    
    [SerializeField] private Rigidbody body;
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -50f;
    [SerializeField] private float rollForce = 20;
    [SerializeField] private float minY;
    [SerializeField] private GameObject gameManager;
    
    
    private float horizontalMovment;
    private bool jumping;
    private bool isGrounded;
    private bool roll;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update() // kod som har med input att göra, frame per seacond
    {
        horizontalMovment = 1;
    
        if (Input.GetKeyDown(KeyCode.W))
        {
            jumping = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            roll = true;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            roll = false;
        }
       

    }
    
    private void FixedUpdate() // fysik uträkning
    {
       GetComponent<Rigidbody>().AddForce(new Vector3(horizontalMovment * speed, gravity, 0));

       if (isGrounded && jumping)
       {
           jumping = false;
           GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
       }

       if (roll)
       {
           if (!isGrounded)
           {
               GetComponent<Rigidbody>().AddForce(Vector3.down * rollForce, ForceMode.Acceleration);
           }
           
       }

       if (transform.position.y < minY)
       {
           GameController.gameOver = true;
       }

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    
    private void OnCollisionExit(Collision other)
    {
        isGrounded = false;
    }
}


