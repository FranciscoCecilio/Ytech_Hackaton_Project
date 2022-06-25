using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float verticalSpeed = 1f;
    public float verticalOffset = -3;
    public float scrollOffset;
    Vector3 startPos;
	private float newPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
    void Update(){
        newPos = Mathf.Repeat(Time.time * - scrollSpeed, scrollOffset);
        transform.position = startPos + Vector3.right * newPos ;
    }
}
