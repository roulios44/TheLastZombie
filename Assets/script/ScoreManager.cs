using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;

    int score =0;
    int highScore = 0;


    private void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore",0);
        this.scoreText.text = score.ToString() + " POINTS";
        this.highScoreText.text ="HIGHSCORE: " + score.ToString() ;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(){
        score +=1;
        scoreText.text = score.ToString() + " POINTS";
        if(highScore<score)PlayerPrefs.SetInt("highscore",score);

    }
}
