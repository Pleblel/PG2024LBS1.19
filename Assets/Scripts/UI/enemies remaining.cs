using TMPro;
using UnityEngine;

public class enemiesremaining : MonoBehaviour
{
    [SerializeField]
    GameObject enemiesRemaining;

    WaveControl EnemiesLeft;

    TextMeshProUGUI textcomponent;
    // Start is called before the first frame update
    void Start()
    {
        textcomponent = enemiesRemaining.GetComponent<TextMeshProUGUI>();
        EnemiesLeft = FindObjectOfType<WaveControl>();
    }

    // Updates the text of the remaining enemies
    void Update()
    {
        string enemies = "enemies remaining: " + (EnemiesLeft.waves[EnemiesLeft.currentWaveIndex].enemiesLeft);
        textcomponent.text = enemies;
    }
}//gjord av Pelle Lucas och Johan
