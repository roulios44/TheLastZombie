using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button start;
    public Button howToPlay;
    public Button closeInstructions;
    public GameObject instructions;

    private LevelLoader levelLoader;

    // Start is called before the first frame update
    void Awake(){
    }
    void Start()
    {
		this.start.onClick.AddListener(this.GameStart);
        this.howToPlay.onClick.AddListener(this.OpenInstructions);
        this.closeInstructions.onClick.AddListener(this.CloseInstructions);
        this.instructions.SetActive(false);
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
}
