using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public QuestBase quest;
    public PlayerController player;
    
    public Text distanceText;
    public float distance;

    public void Update(){

        distance = (transform.position - player.transform.position).magnitude;
        distanceText.text = distance.ToString("F1") + "m";

    }

    
}
