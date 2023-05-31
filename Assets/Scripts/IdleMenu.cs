using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdleMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape)) //if the user presses the escape key
       {
           if (GameIsPaused) //if the game is paused it will use the resume method to resume the game
           {
               Resume();
           }
           else //if the game is not paused it will use the pause method to pause the game
           {
               Pause(); 
           }
       } 
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); //disables pause menu
        Time.timeScale = 1f; //resumes the time in the game
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true); //enables the pause menu
        Time.timeScale = 0f; //stops the time in the game
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); //loads scene in the index zero
    }
    public void ExitGame()
    {
        Debug.Log("Exiting game..");
        Application.Quit();
    }

}//class
