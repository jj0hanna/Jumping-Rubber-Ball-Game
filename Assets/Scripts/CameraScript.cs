using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
   [SerializeField] private Transform target = null;

   private Vector3 offset;
   
    
    void Start()
    {
        offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        //so the camera follows the target/player
     transform.position = Vector3.Lerp
         (transform.position, new Vector3(target.position.x, 0, target.position.z) + offset, Time.deltaTime * 3);
    }
}
