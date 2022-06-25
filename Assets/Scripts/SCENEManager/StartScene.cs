using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScene : MonoBehaviour
{
    public Image gajo_a_flipar;
    public TMP_Text highscoreText;
    float time;

    void Start()
    {
        time = 1f;
        if (!PlayerPrefs.HasKey("highscore")){
            PlayerPrefs.SetFloat("highscore", 0);
        }

        float bestScore = Score.GetBestScore();
        float minutes = Mathf.FloorToInt(bestScore / 60); 
        float seconds = Mathf.FloorToInt(bestScore % 60);
        highscoreText.text = string.Format("BEST TIME: " + "{0:00}:{1:00}", minutes, seconds);
    }
    public void StartGame(){
        SceneManager.LoadScene("Gif");
    }

    public void About(){
        SceneManager.LoadScene("About");
    }

    public void Quit(){
        Application.Quit();
    }

    void Update()
    {
        if(time < 0){
            gajo_a_flipar.transform.localScale = new Vector3 (-gajo_a_flipar.transform.localScale.x,.8f,1);
            time = 1;
        }
        time -= Time.deltaTime;
    }
}
