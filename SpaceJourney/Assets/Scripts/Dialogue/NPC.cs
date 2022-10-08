using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{


    public DialogueTrigger trigger;
    

    public void Trig (){
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
        
    }

}
