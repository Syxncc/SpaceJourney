using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButtons : MonoBehaviour
{


    public void QuestAccept()
    {
        if (QuestManager.instance.CurrentQuest != null)
        {
            QuestManager.instance.CurrentQuest.InitializeQuest();
            QuestManager.instance.questUI.SetActive(false);
        }
    }
}
