using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class DieMenu : MonoBehaviour
{
    public Button buttonRestart;
    public Button mainMenu;
    public Animator transition;
    public float transitionTime = 1f;

    private LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        this.buttonRestart.onClick.AddListener(this.RestartGame);
        this.mainMenu.onClick.AddListener(this.GoMainMenu);

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
