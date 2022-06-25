using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform center;
    Vector3 axis = Vector3.forward;

    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f; 

    public GameOverManager gameOverMng;
    
    void Start() {
        transform.position = (transform.position - center.position).normalized * radius + center.position;
    }
    
    void Update() {
        Rotate();
        
    }

    void Rotate(){
        transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
        var desiredPosition = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Enemy"))
            gameOverMng.ShowGameOverPanel();
    }

    

}
