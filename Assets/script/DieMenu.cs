using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;

public class DieMenu : MonoBehaviour
{
    public EventSystem eventSys;
    private int score;
    private float time;
    public Button buttonRestart;
    public Button mainMenu;
    public Animator transition;
    public float transitionTime = 1f;
    public Text textScore;
    public Text textTime;

    private LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        this.score = ScoreManager.sessionScore;
        this.time = ScoreManager.sessionTime;
        this.buttonRestart.onClick.AddListener(this.RestartGame);
        eventSys.SetSelectedGameObject(this.buttonRestart.gameObject);
        this.mainMenu.onClick.AddListener(this.GoMainMenu);
        this.textTime.text = string.Format("You survived {0:00} secondes",  this.time);
        this.textScore.text = "You have kill "+this.score.ToString()+" humans";

        try
        {
            levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        }
        catch (Exception e)
        {
            levelLoader = null;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void RestartGame()
    {
        levelLoader.StartGame();
    }

    void GoMainMenu()
    {
        levelLoader.ToMainMenu();
    }
}
