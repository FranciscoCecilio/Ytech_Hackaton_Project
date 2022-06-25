using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OutOfZone : MonoBehaviour
{
    public float timer;
    public bool isOut = false;
    public GameOverManager gameOverManager;

    public TMP_Text warningText;

    public void Entered(){
        isOut = true;
        timer = 1.5f;
    }

    public void Exited(){
        isOut = false;
        timer = 1.5f;
    }

    void Update()
    {
        if(timer <= 0){
            //Loose
            gameOverManager.ShowGameOverPanel();
        }
        else if(isOut){
            timer -= Time.deltaTime;
            warningText.gameObject.SetActive(true);
            warningText.text = string.Format("COME BACK!\n" + timer.ToString("F2"));
        }
        else{
            warningText.gameObject.SetActive(false);
        }

        
    }
}
