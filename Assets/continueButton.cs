using UnityEngine;
using UnityEngine.SceneManagement;

public class continueButton : MonoBehaviour
{// g�r s� att spelet startas efter att ha klickat continue.
    public void startgame()
    {
        SceneManager.LoadScene(1);
    }
}
//av Lucas