using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // Starts the game if u press "play"
    public void PlayGame()
    {
        SceneManager.LoadScene(2);

        WaveControl.start = true;
    }
    // Makes the game close if u press "quit"
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
    //starts endless mode
    public void EndlessMode()
    {
        SceneManager.LoadScene(3);
    }
}
//gjord av Lucas