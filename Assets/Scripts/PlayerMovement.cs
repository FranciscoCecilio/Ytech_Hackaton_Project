using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Transform center;
    Vector3 axis = Vector3.forward;

    public float radius = 1.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 2.0f; 
    public float rotationSpeed_initial = 2.0f;
    public float movementSpeed = 0.1f;
    public float pressed_timer_up = 0.2f;
    public float pressed_timer_down = 0.2f;

    public GameOverManager gameOverMng;
    
    void Start() {
        transform.position = ((transform.position - center.position).normalized * radius + center.position);
    }
    
    void Update() {
        Rotate();
        Vector3 upVector = new Vector3(0,1,0);
        if(Input.GetKey(KeyCode.W)){
            pressed_timer_up += Time.deltaTime;
            transform.position = transform.position + upVector*movementSpeed*pressed_timer_up*pressed_timer_up;
            center.transform.position = center.transform.position + upVector*movementSpeed*pressed_timer_up*pressed_timer_up;
        }
        else
        {
            pressed_timer_up = 0.2f;
        }
        if(Input.GetKey(KeyCode.S)){
            pressed_timer_down += Time.deltaTime;
            transform.position = transform.position - upVector*movementSpeed*pressed_timer_down*pressed_timer_down;
            center.transform.position = center.transform.position - upVector*movementSpeed*pressed_timer_down;
        }
        else
        {
            pressed_timer_down = 0.2f;
        }
    }

    void Rotate(){
        transform.RotateAround (center.position, axis, -rotationSpeed * Time.deltaTime);
        var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Portal"){
            if(radius <= 4f) radius = radius + 0.5f;
        }
        if(other.tag == "zone"){
            rotationSpeed = other.GetComponent<Zone>().getValue();
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "zone"){
            rotationSpeed = rotationSpeed_initial;
        }
    }
    
    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Enemy"))
            gameOverMng.ShowGameOverPanel();
    }
}

