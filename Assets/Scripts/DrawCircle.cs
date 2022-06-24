using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Draw(transform.position);
    }

    // Draw circle on XZ plane
    private void Draw(Vector3 position)
    {
        var increment = 10;
        for (int angle = 0; angle < 360; angle = angle + increment)
        {
            var heading = Vector3.forward - position;
            var direction = heading / heading.magnitude;
            var point = position + Quaternion.Euler(0, angle, 0) * Vector3.forward * radius;
            var point2 = position + Quaternion.Euler(0, angle + increment, 0) * Vector3.forward * radius;
            Debug.DrawLine(point, point2, Color.red);
        }
    }
}
