using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingOverSelf : MonoBehaviour
{
    Transform self;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        self.RotateAround(self.position, Vector3.forward, speed * Time.deltaTime);
    }
}
