using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    public LineRenderer circleRenderer;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Draw(100);
    }

    // Draw circle on XZ plane
    private void Draw(int steps)
    {
        circleRenderer.positionCount = steps;
        for(int currentStep = 0; currentStep < steps; currentStep ++){
            float circumferenceProgress = (float)currentStep/steps;
            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);
            
            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = transform.position + new Vector3(x,y,0);

            circleRenderer.SetPosition(currentStep, currentPosition);
        }
    }
    
}
