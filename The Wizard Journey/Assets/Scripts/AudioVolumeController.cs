using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeController : MonoBehaviour
{
    AudioSource audioSource;
    float currentAudioLevel; 
    public float defaultAudioLevel;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetAudioLevel(float newVolume)
    {
        if(audioSource == null)
            audioSource = GetComponent<AudioSource>();
        
        currentAudioLevel = defaultAudioLevel * newVolume;
        audioSource.volume = currentAudioLevel;
    }
}
