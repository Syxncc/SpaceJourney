using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private NPCMove npcMovement;
    public string enterMessage = "";
    public QuestBase locationQuest;
    private string message = "";
    private bool triggeredOnce = false;
    public GameObject canvasObject;
    void Start()
    {
        npcMovement = transform.GetComponentInChildren<NPCMove>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (canvasObject.gameObject != null)
            {
                canvasObject?.SetActive(true);
            }
            if (!triggeredOnce && !GameManager.instance.isDoneAllQuest() && locationQuest != null && QuestManager.instance.CompareQuest(locationQuest, 0))
            {
                triggeredOnce = true;
                message = "You triggered '" + locationQuest.questName + "'";
                locationQuest.InitializeQuest();
            }
            GameManager.instance.PopUpNotification(message + "\n" + enterMessage);
            npcMovement.SetTarget(other.transform);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!npcMovement.isGreedy)
            {
                npcMovement.SetTarget(null);
            }
        }
    }
}
