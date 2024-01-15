using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
        audioMixer.SetFloat("MasterVolume", level);  
    }

    public void SetSoundFXVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume", level);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer.SetFloat("SFXVolume", level);
    }
}
