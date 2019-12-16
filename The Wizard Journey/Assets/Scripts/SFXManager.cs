using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource playerhurt, playerDead, playerAttack, demonDead;

    public static bool audioManagerCreated;
    // Start is called before the first frame update
    void Start()
    {
        //AudioManagerCreated();
    }

    /*void AudioManagerCreated()
    {
        if(!audioManagerCreated)
        {
            audioManagerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
            Destroy(gameObject);
    }*/
}
