using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightManager : MonoBehaviour
{
    public Light main_spotlight;
    public float initial_velocity;

    public Light moving_spotlight;
    public float SmoothTime = 0.3f; // change this value to get desired smoothness
    public Vector3 targetPos; // moving_spotlight will follow this
    private float timer;
    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        main_spotlight.spotAngle = 1;
        ChangeTargetPos();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(main_spotlight.spotAngle < 130f){
            main_spotlight.spotAngle += initial_velocity * Time.deltaTime;
        }

        if(timer > 3f){
            ChangeTargetPos();
            timer = 0;
        }

    }

    public void ChangeTargetPos(){
        targetPos = Random.insideUnitCircle.normalized * 6;
        targetPos.z = moving_spotlight.transform.position.z; 
    }

    void LateUpdate()
    {
        moving_spotlight.transform.position = Vector3.SmoothDamp(moving_spotlight.transform.position, targetPos, ref velocity, SmoothTime);
    }
}
