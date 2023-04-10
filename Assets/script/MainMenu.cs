using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{

    public Button start;
    public Button leaveGame;
    public Button howToPlay;
    public Button closeInstructions;
    public GameObject instructions;
    public GameObject credits;
    public Button closeCredits;
    public Button openCredits;
    private LevelLoader levelLoader;

    // Start is called before the first frame update
    void Awake(){
    }
    void Start()
    {

        #if !UNITY_WEBGL
        this.leaveGame.onClick.AddListener(this.AppliQuit);
        #else
        this.leaveGame.gameObject.SetActive(false);
        #endif

		this.start.onClick.AddListener(this.GameStart);
        this.howToPlay.onClick.AddListener(this.OpenInstructions);
        this.closeInstructions.onClick.AddListener(this.CloseInstructions);
        this.instructions.SetActive(false);
        this.credits.SetActive(false);
        this.openCredits.onClick.AddListener(this.OpenCredits);
        this.closeCredits.onClick.AddListener(this.CloseCredits);
        try{
            levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        }catch(Exception){
            levelLoader = null;
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GameStart(){
        if(this.levelLoader!=null){
            levelLoader.StartGame();
        }
    }
    void OpenInstructions(){
        this.instructions.SetActive(true);
    }

    void CloseInstructions(){
        this.instructions.SetActive(false);
    }

    void CloseCredits(){
        this.credits.SetActive(false);
        this.openCredits.gameObject.SetActive(true);
    }

    void OpenCredits(){
        this.credits.SetActive(true);
        this.openCredits.gameObject.SetActive(false);
    }

    void AppliQuit(){
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
