using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TMP_Text timerText;
    public TMP_Text bestTimeText;

    public static float timeToDisplay;
    public bool isGameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timeToDisplay = 0;

        if (!PlayerPrefs.HasKey("highscore")){
            PlayerPrefs.SetFloat("highscore", 0);
        }

        float bestScore = Score.GetBestScore();
        float minutes = Mathf.FloorToInt(bestScore / 60); 
        float seconds = Mathf.FloorToInt(bestScore % 60);
        bestTimeText.text = string.Format("BEST TIME: " + "{0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver){
            timeToDisplay += Time.deltaTime;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timerText.text = string.Format("TIME: " + "{0:00}:{1:00}", minutes, seconds);
        }
    }
}
