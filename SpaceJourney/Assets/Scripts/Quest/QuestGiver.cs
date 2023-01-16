using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{

    public QuestBase quest;
    private int giverQuestIndex;
    private PlayerController player;
    public GameObject questMarking;

    public TMP_Text distanceText;
    public TMP_Text questDistanceText;
    public float distance;

    private QuestBase[] questSequence;

    void Start()
    {
        player = GameManager.instance.playerManager.playerController;
        //Get the quest of quest giver in Quest Sequence Scriptable Object (QSSO)
        questSequence = GameManager.instance.playerManager.questSequence.questSequence;
        giverQuestIndex = FindQuestInQuestSequence();
    }

    public void Update()
    {
        if (CurrentQuest() && !GameManager.instance.isDoneAllQuest())
        {
            distance = (transform.position - player.transform.position).magnitude;
            distanceText.text = distance.ToString("F1") + "m";
            questDistanceText.text = distance.ToString("F1") + "m";
            questMarking.SetActive(true);
        }
        else
        {
            questMarking.SetActive(false);
        }
    }

    public bool CurrentQuest()
    {
        int currentQuestIndex = GameManager.instance.playerManager.questSequence.currentQuestIndex;
        return giverQuestIndex == currentQuestIndex;
    }

    int FindQuestInQuestSequence()
    {
        for (int i = 0; i < questSequence.Length; i++)
        {
            if (questSequence[i].name == quest.name)
            {
                return i;
            }
        }
        return -1;
    }


}
