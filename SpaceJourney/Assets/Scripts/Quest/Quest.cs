using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    // public GameObject claim;
    public ClaimReward claimRewards;
    

    public string id;
    public string title;
    public string description;
    public int goldReward;

    public QuestGoal goal;
    
    
    public void Complete(){
        
        
        // claim.SetActive(true);
        // isActive = false;
        // claimRewards.Claimed();
        
        
    }

    public void Clear(){
        
        // claimRewards.ClearQuest();
        
        
        
    }


    
}
