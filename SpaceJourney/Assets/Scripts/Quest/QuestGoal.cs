using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    // Start is called before the first frame update
    public GoalType goalType;

    // public GameObject Navigation;


    // [Header("Introduction")]
    // public int requiredAmount;
    // public int currentAmount;

    public bool JoystickMoved(){
        return true;

    }

    // public void ItemGathered(){
    //     if(goalType == GoalType.Gathering){
    //         currentAmount++;
    //     }
    // }
    
    // public bool AmountReached(){
    //     return(currentAmount >= requiredAmount);
    // }

    // [Header("Gathering")]
    // public int requiredAmount;
    // public int currentAmount;

    // public void ItemGathered(){
    //     if(goalType == GoalType.Gathering){
    //         currentAmount++;
    //     }
    // }
    // public bool AmountReached(){
    //     return(currentAmount >= requiredAmount);
    // }
    
    // [Header("Follow")]
    // public int requiredDistance;
    // public int currentDistance;
    // public GameObject destination;
    // public GameObject NPC;

    // public void FollowingCharacter(){
    //     if(goalType == GoalType.Follow){
    //         if (currentDistance < requiredDistance){

    //         }
    //     }
    // }








    [Header("Talk")]
    public string targetNPCTalk;



   

    



    
    












    public enum GoalType{
        Introduction,
        Gathering,
        Follow,
        Syntax,
        Talk,
    }
}
