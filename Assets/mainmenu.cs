using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    //starts the game if u press "play"
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //makes the game close if u press "exit"
    public void quitgame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
