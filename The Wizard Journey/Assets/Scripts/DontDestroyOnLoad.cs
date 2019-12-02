using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    static bool cameraCreated;
    // Start is called before the first frame update
    void Start()
    {
        IsCameraCreated();
        checkPlayerLoad();
    }

    void checkPlayerLoad()
    {
        if(!PlayerController.playerCreated)
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
