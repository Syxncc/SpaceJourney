using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBase : ScriptableObject
{
    public string questName = "";
    [TextArea(5,10)]
    public string questDescription = "";

    public int[] CurrentAmount{get; set;}
    public int[] RequiredAmount{get; set;}

    public bool isCompleted = false;

    [System.Serializable]
    public class Rewards{
        public int goldReward;
    }

    public Rewards rewards;

    public virtual void InitializeQuest(){
        CurrentAmount = new int[RequiredAmount.Length];
    }

    public void Evaluate(){
        for(int i = 0; i < RequiredAmount.Length; i++){
            if(CurrentAmount[i] < RequiredAmount[i]){
                return;
            }
        }
        GameManager.instance.rewardManager.ClaimRewards(this);
        isCompleted = true;
        Debug.LogError("Quest is Completed");
    }
}
