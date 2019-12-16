using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeManager : MonoBehaviour
{
    private AudioVolumeController [] audios;
    public float maxVolumeLevel;
    public float currentVolumeLevel;
    public static bool audioVolumeManagerCreated;
    // Start is called before the first frame update
    void Start()
    {
        AudioVolumeManagerCreated();
        audios = FindObjectsOfType<AudioVolumeController>();
    }
    void Update()
    {
        ChangeGlobalAudioVolume();
    }
    public void ChangeGlobalAudioVolume()
    {
        if(currentVolumeLevel >= maxVolumeLevel)
            currentVolumeLevel = maxVolumeLevel;
        
        foreach(AudioVolumeController audioVolumeCurrent in audios)
        {
            audioVolumeCurrent.SetAudioLevel(currentVolumeLevel);
        }
    }

    void AudioVolumeManagerCreated()
    {
        if(!audioVolumeManagerCreated)
        {
            audioVolumeManagerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
            Destroy(gameObject);
    }
}
