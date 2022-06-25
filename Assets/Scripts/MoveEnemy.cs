using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    
    public float cookieSpeed = 6;
    public float saberSpeed = 5;
    public float statueSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(tag) {
            case "Enemy-Cookie":
                transform.position += Vector3.left * cookieSpeed * Time.deltaTime;
                break;
            case "Enemy-Saber":
                transform.position += Vector3.left * saberSpeed * Time.deltaTime;
                break;
            case "Enemy-Statue":
                transform.position += Vector3.left * statueSpeed * Time.deltaTime;
                break;
             default:
                transform.position += Vector3.left * saberSpeed * Time.deltaTime;
                break;
        }
    }
}
