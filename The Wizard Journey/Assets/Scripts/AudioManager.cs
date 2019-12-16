using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource [] audioTracks;
    public int currentTrack;
    public bool audioCanBePlayed;
    public static bool audioManagerCreated;
    // Start is called before the first frame update
    void Start()
    {
        //AudioBGManagerCreated();   
    }
    void Update()
    {
        PlayBackgroundAudio();
    }
    
    /*void AudioBGManagerCreated()
    {
        if(!audioManagerCreated)
        {
            audioManagerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
            Destroy(gameObject);
    }*/

    void PlayBackgroundAudio()
    {
        if(audioCanBePlayed)
        {
            if(!audioTracks [currentTrack].isPlaying)
            {
                audioTracks[currentTrack].Play();
            }
        }
    }
    public void PlayNewTrack(int newTrack)
    {
        audioTracks[currentTrack].Stop();
        currentTrack = newTrack;
        audioTracks[currentTrack].Play();
    }
}
