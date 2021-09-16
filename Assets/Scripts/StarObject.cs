using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarObject : MonoBehaviour
{
    private GameObject starObject;

    [SerializeField] private float rotationSpeed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0 );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // if the star collide with the player do this
        {
            GameController.stars += 10; // one star = 10 points
            Destroy(gameObject);
        }
    }
}
