using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public string [] dialogs;
    private DialogManager manager;
    public bool playerIsInTheZone;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<DialogManager>();   
        playerIsInTheZone = false; 
    }

    // Update is called once per frame
    void Update()
    {
        TalkWithNPC();
    }

    private void OnTriggerEnter2D(Collider2D npcCollider) 
    {
        if(npcCollider.gameObject.tag.Equals("Player"))
            playerIsInTheZone = true; 
    }
    private void OnTriggerExit2D(Collider2D npcCollider) 
    {
            if(!npcCollider.gameObject.tag.Equals("Player"))
            playerIsInTheZone = false;       
    }
    void TalkWithNPC()
    {
        if(playerIsInTheZone)
        {
            if(Input.GetKeyDown("joystick button 1") || Input.GetMouseButtonDown(1))
            {
                manager.dialogActive = true;
                manager.dialogBox.SetActive(true);
                if(manager.dialogActive)
                {
                    if(Input.GetKeyDown("joystick button 1") || Input.GetMouseButtonDown(1))
                    {
                        manager.ShowDialog(dialogs);
                        if(gameObject.GetComponentInParent<NPCMovement>() != null)
                        {
                            gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
                        }
                    }
                        
                }
            }
        }  
        if(manager.dialogActive)
        {
            manager.checkInputContinueDialog(); 
        }
    }
}
