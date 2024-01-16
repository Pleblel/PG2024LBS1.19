using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class wavecounter : MonoBehaviour
{

    [SerializeField]
    GameObject WaveCounter;

    WaveControl waveControl;

    TextMeshProUGUI textComponent;
    
    void Start()
    {
        textComponent = WaveCounter.GetComponent<TextMeshProUGUI>();
        waveControl = FindObjectOfType<WaveControl>();
    }

    // Updates the counter of waves
    void Update()
    {
        string waves = "Wave: " + (waveControl.currentWaveIndex + 1);
        textComponent.text = waves;
    }
}
//gjord av Lucas och Elm