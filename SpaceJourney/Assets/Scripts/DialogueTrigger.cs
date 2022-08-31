using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    

    void Start(){
        
    }

    public void TriggerDialogue (){
        FindObjectOfType<DialogueManagement>().StartDialogue(dialogue);
    }

}
