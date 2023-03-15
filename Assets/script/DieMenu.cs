using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DieMenu : MonoBehaviour
{
    public Button buttonRestart;
    public Button mainMenu;
    // Start is called before the first frame update
    void Start()
    {
		buttonRestart.onClick.AddListener(RestartGame);
		mainMenu.onClick.AddListener(GoMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RestartGame(){
        SceneManager.LoadScene("MainScene");
    }

    void GoMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
