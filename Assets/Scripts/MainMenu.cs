using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame () //creates a PlayGame method
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads the scene in the index 1
    }
    
    public void ExitGame () //creates a ExitGame method
    {
        Debug.Log ("QUIT!");
        Application.Quit();
    }
}
