using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class PauseManager : MonoBehaviour
{

    public GameObject sceneManager;
    public Button resume;
    public Button commands;
    public Button mainMenu;
    public Button closeCommands;

    public GameObject menuObject;

    public GameObject commandsObject;

    public EventSystem eventSys;


    // Start is called before the first frame update
    void Start()
    {
        this.menuObject.SetActive(false);
        this.commandsObject.SetActive(false);
		this.resume.onClick.AddListener(this.Resume);
        this.commands.onClick.AddListener(this.ShowCommands);
        this.mainMenu.onClick.AddListener(this.GoMainMenu);
        this.closeCommands.onClick.AddListener(this.CloseCommands);
        eventSys.SetSelectedGameObject(this.resume.gameObject);
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
        this.resume.gameObject.SetActive(false);
        this.commands.gameObject.SetActive(false);
        this.mainMenu.gameObject.SetActive(false);
        eventSys.SetSelectedGameObject(this.closeCommands.gameObject);

    }
    void GoMainMenu(){
        this.sceneManager.GetComponent<LevelLoader>().ToMainMenu();
    }
    void CloseCommands(){
        this.commandsObject.SetActive(false);
        this.resume.gameObject.SetActive(true);
        this.commands.gameObject.SetActive(true);
        this.mainMenu.gameObject.SetActive(true);
        eventSys.SetSelectedGameObject(this.resume.gameObject);
    }
}
