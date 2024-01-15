using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{

    public AudioSource clickSFX;

    public void playButton()
    {
        clickSFX.Play();
    }
    // Starts the game if u press "play"
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        WaveControl.start = true;

    }
    // Makes the game close if u press "exit"
    public void quitgame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
