using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive; 

    string [] dialogLines;
    public int currentDialogLine;
    NPCDialog npcManager;


    void Start()
    {
        currentDialogLine = 0;
    }
    public void checkInputContinueDialog()
    {
        if(currentDialogLine >= dialogLines.Length)
        {
            if(Input.GetKeyDown("joystick button 1") || Input.GetMouseButtonDown(1))
            {
                dialogActive = false;
                dialogBox.SetActive(false);
                currentDialogLine = 0;
            }
        }    
    }
    public void ShowDialog(string[] dialogs)
    {
        dialogLines = dialogs;
        dialogText.text = dialogs[currentDialogLine];
        currentDialogLine++;
    }
}
