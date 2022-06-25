using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Transform center;
    Vector3 axis = Vector3.forward;

    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 2.0f; 
    public float movementSpeed = 0.1f;
    
    void Start() {
        transform.position = ((transform.position - center.position).normalized * radius + center.position);
    }
    
    void Update() {
        Rotate();
        Vector3 upVector = new Vector3(0,1,0);
        if(Input.GetKey(KeyCode.W)){
            transform.position = transform.position + upVector*movementSpeed;
            center.transform.position = center.transform.position + upVector*movementSpeed;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position = transform.position - upVector*movementSpeed;
            center.transform.position = center.transform.position - upVector*movementSpeed;
        }

    void Rotate(){
        transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
        var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Portal"){
            radius = radius + 1;
        }
        if(other.tag == "Slow_Zone"){
            GetComponent;
        }
        if(other.tag == "Fast_Zone"){
            rotationSpeed = rotationSpeed*2;
        }
        if(other.tag == "Normal_Zone"){
            rotationSpeed = rotationSpeed;
        }
    }
}
}
