using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // Starts the game if u press "play"
    public void playGame()
    {
        SceneManager.LoadScene(2);

        WaveControl.start = true;
    }
    // Makes the game close if u press "quit"
    public void quitgame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
