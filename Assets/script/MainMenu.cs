using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Button start;
    public Button howToPlay;
    public Button closeInstructions;
    public GameObject instructions;

    public 
    // Start is called before the first frame update
    void Start()
    {
		this.start.onClick.AddListener(this.GameStart);
        this.howToPlay.onClick.AddListener(this.OpenInstructions);
        this.closeInstructions.onClick.AddListener(this.CloseInstructions);
        this.instructions.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GameStart(){
        SceneManager.LoadScene("MainScene");
    }
    void OpenInstructions(){
        Debug.Log("open instructions");
        this.instructions.SetActive(true);

    }

    void CloseInstructions(){
        Debug.Log("close instructions");
        this.instructions.SetActive(false);

    }
}
