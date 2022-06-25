using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getValue(){
        System.Random rd = new System.Random();
        int rand = rd.Next(2);

        switch(rand){
            case 0:
                return 0.5f;
                break;

            case 1:
                return 2.0f;
                break;

            default:
                return 1.0f;
                break;
        }
    }
}
