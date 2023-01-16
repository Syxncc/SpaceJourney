using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBase : ScriptableObject
{
    public string questID;
    public string questName = "";
    [TextArea(5, 10)]
    public string questDescription = "";

    public int[] CurrentAmount { get; set; }
    public int[] RequiredAmount { get; set; }
    public bool isAutoQuest = false;
    public float maxTime = 0;
    public float currentHighScore = 0;
    public bool isQuestTimerObjective = false;
    private IEnumerator coroutine;

    [System.Serializable]
    public class Rewards
    {
        public int goldReward;
        public int xpReward;
        public Collectible[] collectibles;
    }

    public Rewards rewards;

    public virtual void InitializeQuest()
    {
        CurrentAmount = new int[RequiredAmount.Length];
    }

    public void Evaluate(bool isDelayingNotification)
    {
        for (int i = 0; i < RequiredAmount.Length; i++)
        {
            if (CurrentAmount[i] < RequiredAmount[i])
            {
                return;
            }
        }
        GameManager gameManager = GameManager.instance;
        // gameManager.rewardManager.ClaimRewards(this);
        Debug.LogError("Quest is Completed");
        QuestSequence playerQuest = gameManager.playerManager.questSequence;
        if ((playerQuest.currentQuestIndex) < playerQuest.questSequence.Length - 1)
        {
            playerQuest.currentQuestIndex++;
            Debug.LogError(playerQuest.questSequence.Length + " " + playerQuest.currentQuestIndex);
            if (playerQuest.questSequence[playerQuest.currentQuestIndex].isAutoQuest)
            {
                Debug.LogError("Working");
                QuestManager.instance.SetQuestUI(playerQuest.questSequence[playerQuest.currentQuestIndex]);
            }
        }
        else
        {
            playerQuest.isQuestDone = true;
        }
        GameManager.instance.ChangeMessagePopupPanel(false, this, false);

        // if (isDelayingNotification)
        // {
        //     coroutine = DelayCompletedQuest(3.0f);
        //     gameManager.StartCoroutine(coroutine);
        // }
        // else
        // {
        gameManager.rewardManager.ClaimRewards(this);
        gameManager.SaveCurrentCharacterPosition();
        // }
        gameManager.onTalkNPCCallback = null;
        gameManager.onDestinationCallback = null;
    }
    // IEnumerator DelayCompletedQuest(float delayTime)
    // {
    //     // suspend execution for 5 seconds
    //     yield return new WaitForSeconds(delayTime);
    //     GameManager.instance.rewardManager.ClaimRewards(this);
    // }
}
