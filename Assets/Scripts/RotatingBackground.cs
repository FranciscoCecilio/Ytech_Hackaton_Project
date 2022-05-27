using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBackground : MonoBehaviour
{
    Transform background;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        background.RotateAround(background.position, Vector3.forward, speed * Time.deltaTime);
    }
}
