using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    static bool cameraCreated;
    // Start is called before the first frame update
    private void Awake()
    {
        IsCameraCreated();
        checkPlayerLoad();
        CheckUIManagerCreator();
        //CheckSFXManagerCreator();
        //CheckAudioManagerCreator();
        CheckAudioVolumeManagerCreator();
    }

    void checkPlayerLoad()
    {
        if(!PlayerController.playerCreated)
            DontDestroyOnLoad(this.transform.gameObject);
        else
            Destroy(gameObject);
    }
    void CheckUIManagerCreator()
    {
        if(!UIManager.uiManagerCreated)
            DontDestroyOnLoad(this.transform.gameObject);
        else
            Destroy(gameObject);
    }
    /*void CheckSFXManagerCreator()
    {
        if(!SFXManager.audioManagerCreated)
            DontDestroyOnLoad(this.transform.gameObject);
        else
            Destroy(gameObject);     
    }
    void CheckAudioManagerCreator()
    {
        if(!AudioManager.audioManagerCreated)
            DontDestroyOnLoad(this.transform.gameObject);
        else
            Destroy(gameObject);
    }*/
    void CheckAudioVolumeManagerCreator()
    {
        if(!AudioVolumeManager.audioVolumeManagerCreated)
            DontDestroyOnLoad(this.transform.gameObject);
        else
            Destroy(gameObject);
    }
    void IsCameraCreated()
    {
        if(!cameraCreated)
        {
            cameraCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else
            Destroy(gameObject);
    }
}
