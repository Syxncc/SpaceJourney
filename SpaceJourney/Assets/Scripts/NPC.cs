using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{


    public DialogueTrigger trigger;
    //public Transform transform;

    //public GameObject objectToFind;

    public void OnCollisionEnter(Collision collision){
        
        
        
    }






    //     if (other.tag == "NPC"){

    //         DialogueTrigger dialTrig = other.GetChildComponent<DialogueTrigger>();
            // GetComponent<DialogueTrigger>();
            // if (dialTrig!=null){
                // dialTrig.TriggerDialogue();
            // }
            //trigger = other.GameObject.GetComponent<GameObject>();
            //objectToFind = other.gameObject;

            
    //     }
    

    // public void OnTriggerExit(Collider other){
    //     if (other.tag == "NPC"){
            
    //     }
    // }

    public void Trig (){
        trigger.TriggerDialogue();
        // dialTrig.TriggerDialogue();
    }

}
