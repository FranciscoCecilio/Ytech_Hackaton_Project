using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    [Header("TimerScript")]
    public TimerScript timerscript;
    public GameObject panel; // highscore score; score desta ronda; botao de restart 
    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;

    public bool isImortal = false;
    public TMP_Text isImortaltext;

    public void ShowGameOverPanel(){
        if(isImortal) return;
        
        Score.SetDuration(TimerScript.timeToDisplay);
        Score.GameOver();
        // parar o temporizador
        timerscript.isGameOver = true;
        panel.SetActive(true);
        // atualizar os texts
        currentScoreText.text = timerscript.timerText.text;
        highScoreText.text = timerscript.bestTimeText.text;
    }

    // reload the scene
    public void Restart(){
        SceneManager.LoadScene("GameScene");
    }

    public void ImortalButton(){
        isImortal = !isImortal;
        if(isImortal) isImortaltext.text = "ImortalMode: ON"; 
        else isImortaltext.text = "ImortalMode: OFF"; 
    }
}
