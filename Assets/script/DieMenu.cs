using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DieMenu : MonoBehaviour
{
    public Button buttonRestart;
    public Button mainMenu;
    public Animator transition;
    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
		this.buttonRestart.onClick.AddListener(this.RestartGame);
		this.mainMenu.onClick.AddListener(this.GoMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RestartGame(){
        transitionRrestartGame();
    }

    IEnumerator transitionRrestartGame(){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("MainScene");
    }

    void GoMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
