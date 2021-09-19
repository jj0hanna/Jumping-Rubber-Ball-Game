using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float gravity = -50f;
    [SerializeField] private float rollForce = 20;
    [SerializeField] private float minY;
    
    private float horizontalMovment;
    private bool jumping;
    private bool isGrounded;
    private bool roll;
    

    // Update is called once per frame
    void Update() // kod som har med input att göra, frame per seacond
    {
        horizontalMovment = 1; //set the player to move forward
    
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
       GetComponent<Rigidbody>().AddForce(new Vector3(horizontalMovment * speed, gravity, 0)); //calculate the forward speed

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
       
       if (transform.position.y < minY) //if player fall off the map, gameover
       {
           GameController.gameOver = true;
           
           AudioManager.PlaySound("GameOver");
           AudioManager.PlaySound("MenuMusic");
           AudioManager.StopSound("IngameMusic");
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


