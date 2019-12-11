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
