using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Transform center;
    Vector3 axis = Vector3.forward;

    public float radius = 1.0f;
    public float radiusSpeed = 0.2f; 
    public float rotationSpeed = 2.0f; 
    float rotationSpeed_initial;
    public float movementSpeed = 0.1f;
    public float pressed_timer_up = 0.2f;
    public float pressed_timer_down = 0.2f;

    public GameOverManager gameOverMng;
    public SoundManager sM;
    public OutOfZone script;

    void Start() {
        rotationSpeed_initial = rotationSpeed;
        transform.position = ((transform.position - center.position).normalized * radius + center.position);
    }
    
    void Update() {
        Rotate();
        Vector3 upVector = new Vector3(0,1,0);
        if(Input.GetKey(KeyCode.W)){
            pressed_timer_up += Time.deltaTime;
            transform.position = transform.position + upVector*movementSpeed/*pressed_timer_up*pressed_timer_up*/;
            center.transform.position = center.transform.position + upVector*movementSpeed/*pressed_timer_up/*pressed_timer_up*/;
        }
        if(Input.GetKey(KeyCode.S)){
            pressed_timer_down += Time.deltaTime;
            transform.position = transform.position - upVector*movementSpeed/*pressed_timer_down*pressed_timer_down*/;
            center.transform.position = center.transform.position - upVector*movementSpeed/*pressed_timer_down/*pressed_timer_down*/;
        }
    }

    void Rotate(){
        transform.RotateAround (center.position, axis, -rotationSpeed * Time.deltaTime);
        var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }

    void OnTriggerEnter2D(Collider2D other){
            Debug.Log(other.tag);
        if(other.tag == "Portal"){
            Debug.Log(radius);
            if(radius <= 3f){
                radius = radius + 0.2f;
                center.gameObject.GetComponent<DrawCircle>().radius = radius;
            }
            else{
                radius = 2f;
                center.gameObject.GetComponent<DrawCircle>().radius = radius;
            }
        }
        if(other.tag == "zone"){
            rotationSpeed *= other.GetComponent<Zone>().getValue();
        }
        if(other.tag == "out_of_zone"){
            script.Entered();
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "zone"){
            rotationSpeed = rotationSpeed_initial;
        }
        else if(other.tag == "out_of_zone"){
            script.Exited();
        }
    }
    
    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.tag);
        if(col.gameObject.tag.Equals("Enemy-Statue")||col.gameObject.tag.Equals("Enemy-Saber")||col.gameObject.tag.Equals("Enemy-Cookie")){
            sM.PlayOneShot("explosion");
            gameOverMng.ShowGameOverPanel();

        }
        
    }
}

