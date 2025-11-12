using UnityEngine;
using TMPro;

public class EndlessTimer : MonoBehaviour
{
    public TextMeshProUGUI textcomponent;
    public PlayerHealth playerHealth;  // Referens till PlayerHealth
    float timer;

    void Start()
    {
       
        textcomponent = GetComponent<TextMeshProUGUI>();
        if (playerHealth == null)
            playerHealth = FindObjectOfType<PlayerHealth>();
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
       

        
    }
}