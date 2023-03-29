using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{

    public static int sessionScore;
    public static float sessionTime;
    public static ScoreManager instance;
    public GameObject zombie;
    private Zombie character;
    public Text scoreText;
    public Text highScoreText;
    public Text timerTxt;
    public float currentTime;
    public Text purseText;

    public Text zombieLife;

    int score = 0;
    int highScore = 0;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.character = zombie.GetComponent<Zombie>();
        this.highScore = PlayerPrefs.GetInt("highscore", 0);
        this.scoreText.text = score.ToString() + " POINTS";
        this.highScoreText.text = "HIGHSCORE: " + score.ToString();
        this.purseText.text = "Purse: " + character.purse.ToString();
        this.zombieLife.text = "HP: " + character.currentHP.ToString() + " / " + character.maxHP.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        this.currentTime += Time.deltaTime;
        this.UpdateTimer(this.currentTime);
        this.purseText.text = "Purse: " + this.character.purse.ToString();
        this.zombieLife.text = "HP: " + this.character.currentHP.ToString() + " / " + character.maxHP.ToString();
        sessionScore = this.score;
        sessionTime = this.currentTime;
    }

    public void AddPoint()
    {
        this.score += 1;
        this.scoreText.text = this.score.ToString() + " POINTS";
        if (highScore < score) PlayerPrefs.SetInt("highscore", score);
    }

    void UpdateTimer(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float secondes = Mathf.FloorToInt(time % 60);

        this.timerTxt.text = string.Format("{0:00} : {1:00}", minutes, secondes);
    }
}
