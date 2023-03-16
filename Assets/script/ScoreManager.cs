using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;
    public Text timerTxt;

    public float currentTime;


    int score =0;
    int highScore = 0;


    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.highScore = PlayerPrefs.GetInt("highscore",0);
        this.scoreText.text = score.ToString() + " POINTS";
        this.highScoreText.text ="HIGHSCORE: " + score.ToString() ;

    }

    // Update is called once per frame
    void Update()
    {
        this.currentTime += Time.deltaTime;
        this.updateTimer(currentTime);
    }

    public void AddPoint(){
        this.score +=1;
        this.scoreText.text = score.ToString() + " POINTS";
        if(highScore<score)PlayerPrefs.SetInt("highscore",score);
    }

    void updateTimer(float time){
        float minutes = Mathf.FloorToInt(time/60);
        float secondes = Mathf.FloorToInt(time%60);

        this.timerTxt.text = string.Format("{0:00} : {1:00}",minutes,secondes);
    }
}
