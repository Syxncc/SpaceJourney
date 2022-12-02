using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    public Text questName;
    public GameObject questRewardUI;

    public QuestBase quest;

    public InfoCards[] infoCardsPlanet;
    public InfoCards[] infoCardsConstellations;

    public void Start(){
        // SetRewardUI(quest);
    }

    public void ClaimRewards(QuestBase quest){
        PlayerManager.playergold += quest.rewards.goldReward;
        PlayerManager.currentXP += quest.rewards.xpReward;
        if (quest.rewards.infoCardsCategory == "Planets"){

            for(int i = 0; i < infoCardsPlanet.Length; i++){
                if(infoCardsPlanet[i].infoName == quest.rewards.infoCards){
                    infoCardsPlanet[i].unlock = true;
                    break;
                }
                
            }

        }
        else if (quest.rewards.infoCardsCategory == "Constellations"){
            for(int i = 0; i < infoCardsPlanet.Length; i++){
                if(infoCardsPlanet[i].infoName == quest.rewards.infoCards){
                    infoCardsPlanet[i].unlock = true;
                    break;
                }
            }
        }
        else if (quest.rewards.infoCardsCategory == "Others"){

        }
        else {
            Debug.LogError("NO INFOCARDS REWARDS SET");
        }
        //Debug.LogError(GameManager.instance.playerManager.gold.ToString());
        
        // questName.text = quest.questName;
        //questRewardUI.SetActive(true);
    }
    

}
