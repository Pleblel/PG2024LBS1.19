using UnityEngine;
using UnityEngine.SceneManagement;

public class continueButton : MonoBehaviour
{// gör så att spelet startas efter att ha klickat continue.
    public void startgame()
    {
        SceneManager.LoadScene(1);
    }
}
//av Lucas