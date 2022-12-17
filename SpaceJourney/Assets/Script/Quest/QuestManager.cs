using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            if (GameManager.instance != null)
            {
                QuestSequence playerQuest = GameManager.instance.playerQuest;
                if (CurrentQuest == null && playerQuest.currentQuestIndex != 0 && playerQuest.currentQuestIndex < playerQuest.questSequence.Length - 1)
                {
                    CurrentQuest = playerQuest.questSequence[playerQuest.currentQuestIndex];
                    CurrentQuest.InitializeQuest();
                }
            }
        }
    }
    public GameObject questUI;
    public GameObject questText;
    public TMP_Text questName;
    public TMP_Text questDescription;
    public TMP_Text questGoldReward;
    public TMP_Text questXPReward;

    public QuestBase CurrentQuest { get; set; }
    public GameObject acceptButton;

    void Start()
    {
    }

    public void SetQuestUI(QuestBase newQuest)
    {
        questText.SetActive(true);
        CurrentQuest = newQuest;
        questUI.SetActive(true);
        acceptButton.SetActive(true);
        questName.text = newQuest.questName;
        questDescription.text = newQuest.questDescription;
        questGoldReward.text = newQuest.rewards.goldReward.ToString();
        questXPReward.text = newQuest.rewards.xpReward.ToString();
    }

    public void SetDoneQuest()
    {
        if (GameManager.instance.isDoneQuest())
        {
            questName.text = "Unavailable Quest";
            questDescription.text = "You have no available quest.";
        }
        else
        {
            QuestSequence playerQuest = GameManager.instance.playerQuest;
            QuestBase newQuest = playerQuest.questSequence[playerQuest.currentQuestIndex];
            questName.text = newQuest.questName;
            questDescription.text = newQuest.questDescription;
            questGoldReward.text = newQuest.rewards.goldReward.ToString();
            questXPReward.text = newQuest.rewards.xpReward.ToString();
        }
    }
}
