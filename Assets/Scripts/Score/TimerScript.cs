using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText;
    float timeToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        timeToDisplay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeToDisplay += Time.deltaTime;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
