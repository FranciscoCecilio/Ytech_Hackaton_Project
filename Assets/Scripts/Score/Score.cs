using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        // guardar o highscore nos playerprefs
    }


}
