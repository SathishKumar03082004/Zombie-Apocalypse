using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [Header("All Game Menus")]
    public GameObject pauseMenuUI;
    public GameObject endGameMenuUI;
    public GameObject objectiveMenuUI;

    public static bool GameIsStopped = false;



    private void Update() {
        if(Input.GetKeyUp(KeyCode.Escape)) {
            if(GameIsStopped){
                Resume();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else{
                Pause();
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if(Input.GetKeyDown("o")){
            if(GameIsStopped){
                removeObjectives();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else{
                showObjectives();
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void showObjectives(){
        objectiveMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsStopped = true;
    }

    public void removeObjectives(){
        objectiveMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsStopped = false;
    }


    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsStopped = false;
    }


    public void Restart(){
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
        Debug.Log("Game is Quiting....");
        Application.Quit();
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsStopped = true;
    }
}
