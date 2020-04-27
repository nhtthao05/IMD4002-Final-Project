using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialoguetrigger : MonoBehaviour
{
   public object_dialoge dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<dialogueManager>().StartDialogue(dialogue);
    }
}
