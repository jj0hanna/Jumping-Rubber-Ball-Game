using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
   [SerializeField] private Transform target = null;

   private Vector3 offset;
   
    
    void Start()
    {
        offset = transform.position - target.position;
        
    }
    void LateUpdate()
    {
        
     transform.position = Vector3.Lerp
         (transform.position, new Vector3(target.position.x, 0, target.position.z) + offset, Time.deltaTime * 3);
    }
}
