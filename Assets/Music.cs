using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Music : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    WaveControl waveControl;
    int wave;
    bool bossMusicTime = true;


    //reference script
    private void Start()
    {
        waveControl = FindObjectOfType<WaveControl>();
    }


    // Update is called once per frame
    void Update()
    {
        wave = (waveControl.currentWaveIndex + 1);
        if (wave == 2 && bossMusicTime)
        {
            BossMusic(1);
            bossMusicTime=false;
        }
    }


    public void BossMusic (float level)
    {
        //Sets volume to 0 on background music
        audioMixer.SetFloat("BackgroundMusic", level);
        level = 0;

        //Starts Boss Music

    }
}
