using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public ClaimReward claimReward;
    public PlayerController player;
    private bool acceptable = true;
    

    // public QuestSlotHandler[] questSlot;

    public Text titleText;
    public Text descText;
    public Text goldRewardText;

    public void Update(){

        // if(!questSlot[0].isEmpty && !questSlot[1].isEmpty && !questSlot[2].isEmpty){
        //     Debug.Log("Finish Current Quest");
        // }
        // else {
        //     for(int i = 0; i <3 ; i++){
                
        //         if (questSlot[i].isEmpty){
        //             Debug.Log(questSlot[i]);
        //             Debug.Log("Quest Slot " + i);

        //             questSlot[i].gameObject.SetActive(true);

        //             titleText = questSlot[i].text1;
        //             descText = questSlot[i].text2;
        //             goldRewardText = questSlot[i].text3;

        //             questSlot[i].isEmpty = false;
        //             break;
        //         }
        //     }
        // }

    }

    public void AcceptQuest(){

        if(acceptable && !player.quest.isActive){
            titleText.text = quest.title;
            descText.text = quest.description;
            goldRewardText.text = quest.goldReward.ToString();
            quest.isActive = true;
            player.quest = quest;
            claimReward.quest = quest;
            claimReward.questTexts.SetActive(true);
            acceptable = false;
            
        }

        
    }

    
}
