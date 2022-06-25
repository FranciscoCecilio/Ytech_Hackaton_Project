using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Zone : MonoBehaviour
{

    public float getValue(){
        System.Random rd = new System.Random();
        int rand = rd.Next(2);

        switch(rand){
            case 0:
                return 0.5f;

            case 1:
                return 2.0f;

            default:
                return 1.0f;
        }
    }
}
