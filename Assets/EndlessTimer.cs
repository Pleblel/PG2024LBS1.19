using UnityEngine;
using TMPro;

public class EndlessTimer : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public TextMeshProUGUI bestTimeText;
    public PlayerHealth playerHealth;  // Referens till PlayerHealth
    float timer;
    float bestTime;
    bool timeSaved = false;

    void Start()
    {
        bestTime = PlayerPrefs.GetFloat("bestTime", 0f);
        textcomponent = GetComponent<TextMeshProUGUI>();
        if (playerHealth == null)
            playerHealth = FindObjectOfType<PlayerHealth>();
        if (bestTime > 0f)
        {
            bestTimeText.text = "Best time: " + bestTime.ToString("F2");
        }
        else
            bestTimeText.text = "Best time: N/A";
    }

    void Update()
    {
        // Uppdatera texten
        textcomponent.text = "You have survived for " + Mathf.Round(timer) + " seconds!";

        if (playerHealth.isDead == null) return;

        if (playerHealth.isDead == false)
        {
            timer += Time.deltaTime;
        }
        else if (!timeSaved)
        {
            if(bestTime == 0f || timer > bestTime)
            {
                bestTime = timer;
                PlayerPrefs.SetFloat("bestTime", bestTime);
                PlayerPrefs.Save();

                bestTimeText.text = "Best time: " + bestTime.ToString("F2");
            }
        }
       

        
    }
}