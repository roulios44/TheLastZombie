using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public GameObject sceneManager;
    public Button resume;
    public Button commands;
    public Button mainMenu;
    public Button closeCommands;

    public GameObject menuObject;

    public GameObject commandsObject;


    // Start is called before the first frame update
    void Start()
    {
        this.menuObject.SetActive(false);
        this.commandsObject.SetActive(false);
		this.resume.onClick.AddListener(this.Resume);
        this.commands.onClick.AddListener(this.ShowCommands);
        this.mainMenu.onClick.AddListener(this.GoMainMenu);
        this.closeCommands.onClick.AddListener(this.CloseCommands);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Resume(){
        this.menuObject.SetActive(false);
        Time.timeScale = 1;
    }   
    void ShowCommands(){
        this.commandsObject.SetActive(true);
    }
    void GoMainMenu(){
        this.sceneManager.GetComponent<LevelLoader>().ToMainMenu();
        // SceneManager.LoadScene("MainMenu");
    }
    void CloseCommands(){
        this.commandsObject.SetActive(false);
    }
}
