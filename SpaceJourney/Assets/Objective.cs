using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public Quest quest;
    public PlayerController player;
    

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            
                quest.Complete();
        }
    }
}
