using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LetsPlayWithXboxControl();
    }
    public void LetsPlay()
    {        
        SceneManager.LoadScene("MainScene");
    }
    void LetsPlayWithXboxControl()
    {
        if(Input.GetKeyDown("joystick button 0"))
            SceneManager.LoadScene("MainScene");
    }
}
