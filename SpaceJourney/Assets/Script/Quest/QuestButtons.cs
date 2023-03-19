using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButtons : MonoBehaviour
{

    public void QuestAccept()
    {
        QuestManager questManager = QuestManager.instance;
        // if (questManager.CurrentQuest != GameManager.instance.playerQuest.questSequence[GameManager.instance.playerQuest.currentQuestIndex])
        // {
        questManager.CurrentQuest.InitializeQuest();
        // }
        questManager.questUI.SetActive(false);
    }
}
