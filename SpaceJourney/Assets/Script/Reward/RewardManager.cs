using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardManager : MonoBehaviour
{
    public Text questName;
    public GameObject questRewardUI;

    public QuestBase quest;

    public void Start(){
        // SetRewardUI(quest);
    }

    public void ClaimRewards(QuestBase quest){
        PlayerManager.playergold += quest.rewards.goldReward;
        //Debug.LogError(GameManager.instance.playerManager.gold.ToString());
        // questRewardUI.SetActive(true);
        // questName.text = quest.questName;
    }
}
