using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive; 

    public string [] dialogLines;
    public int currentDialogLine;
    NPCDialog npcManager;

    private PlayerController playerController;

    void Start()
    {
        currentDialogLine = 0;
        playerController = FindObjectOfType<PlayerController>();
        npcManager = GetComponentInChildren<NPCDialog>();
    }
    public void checkInputContinueDialog()
    {
        Debug.Log("este es el currentDialog: " + currentDialogLine);
        if(currentDialogLine >= dialogLines.Length)
        {
            if(Input.GetKeyDown("joystick button 1") || Input.GetMouseButtonDown(1))
            {
                dialogActive = false;
                dialogBox.SetActive(false);
                playerController.playerIsTalking = false;
                currentDialogLine = 0;
            }
        }    
    }
    public void ShowDialog(string[] dialogs)
    {
        dialogLines = dialogs;
        playerController.playerIsTalking = true;
        dialogText.text = dialogs[currentDialogLine];
        currentDialogLine++;
    }
}
