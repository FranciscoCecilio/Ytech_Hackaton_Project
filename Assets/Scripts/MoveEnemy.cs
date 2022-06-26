using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    
    public float cookieSpeed = 6;
    public float saberSpeed = 5;
    public float statueSpeed = 3;

    private float difficulty = 1.0f;

    public void IncreaseDifficulty(float enemyDifficulty){
        difficulty = enemyDifficulty;
    }

    // Update is called once per frame
    void Update()
    {
        switch(tag) {
            case "Enemy-Cookie":
                transform.position += Vector3.left * cookieSpeed * difficulty * Time.deltaTime;
                break;
            case "Enemy-Saber":
                transform.position += Vector3.left * saberSpeed * difficulty * Time.deltaTime;
                break;
            case "Enemy-Statue":
                transform.position += Vector3.left * statueSpeed * difficulty * Time.deltaTime;
                break;
             default:
                transform.position += Vector3.left * saberSpeed * difficulty * Time.deltaTime;
                break;
        }
    }


}
