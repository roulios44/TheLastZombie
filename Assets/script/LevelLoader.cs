using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{
    public Zombie zombie = null;
    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame
    void Update()
    {
        if(zombie!=null){
            if(!zombie.IsAlive()){
                StartCoroutine(this.LoadDeadScreen());
            }
        }
    }

    void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }

    public void ToMainMenu(){
        Time.timeScale =1;
        StartCoroutine(this.LoadLevel(0));
    }

    public void StartGame(){
        StartCoroutine(this.LoadLevel(1));
    }

    public IEnumerator LoadDeadScreen(){
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);

        SceneManager.LoadSceneAsync("DieScene");
    }

    public IEnumerator LoadLevel(int levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);

        SceneManager.LoadSceneAsync(levelIndex);
    }

    IEnumerator LoadMainMenu(){
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);

        SceneManager.LoadSceneAsync("MainMenu");
    }
}
