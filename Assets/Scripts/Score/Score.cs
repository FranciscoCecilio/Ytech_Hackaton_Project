using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Score
{
    static float _duration; // em segundos
    public static int _score; // em segundos

    // chamado na scene do jogo
    public static void SetDuration(float duration){
        _duration = duration;
    }

    // chamado na scene do gameover
    public static void GameOver(){
        // calcular o score
	_score = Math.Pow(1.2, _duration)
        // guardar o highscore nos playerprefs
    }
    
    public static int GetScore(){
    	return _score
    }


}
