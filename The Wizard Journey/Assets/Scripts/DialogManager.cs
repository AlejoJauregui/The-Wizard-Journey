using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive; 


    public void checkInputContinueDialog()
    {
        if(Input.GetKeyDown("joystick button 2") || Input.GetMouseButtonDown(1))
        {
            dialogActive = false;
            dialogBox.SetActive(false);
        }
    }
    public void ShowDialog(string textDialog)
    {
        dialogText.text = textDialog;
    }
}
