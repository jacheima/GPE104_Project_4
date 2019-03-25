using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public Dialogue dialogue;
    public DialogueManager dialogueManager;

    private void OnTriggerEnter2D(Collider2D other)
    {

        dialogueManager.StartDialogue(dialogue);


    }

    private void OnTriggerExit2D(Collider2D other)
    {
       
        
        dialogueManager.EndDialogue();
        
        
    }

}
 