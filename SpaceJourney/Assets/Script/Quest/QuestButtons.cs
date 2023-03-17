using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButtons : MonoBehaviour
{

    public void QuestAccept()
    {
        QuestManager questManager = QuestManager.instance;
        Debug.Log(questManager.CurrentQuest + " " + GameManager.instance.playerQuest.questSequence[GameManager.instance.playerQuest.currentQuestIndex]);
        // if (questManager.CurrentQuest != GameManager.instance.playerQuest.questSequence[GameManager.instance.playerQuest.currentQuestIndex])
        // {
        Debug.Log("Initiasdlasdih Here 1");
        questManager.CurrentQuest.InitializeQuest();
        // }
        questManager.questUI.SetActive(false);
    }
}
