using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    public GameObject questUI;
    public GameObject questText;
    public Text questName;
    public Text questDescription;
    public Text questGoldReward;
    public Text questXPReward;

    public QuestBase CurrentQuest {get; set;}

    public void SetQuestUI(QuestBase newQuest){
        questText.SetActive(true);
        CurrentQuest = newQuest;
        questUI.SetActive(true);
        questName.text = newQuest.questName;
        questDescription.text = newQuest.questDescription;
        questGoldReward.text = newQuest.rewards.goldReward.ToString();
        questXPReward.text = newQuest.rewards.xpReward.ToString();
    }
}
