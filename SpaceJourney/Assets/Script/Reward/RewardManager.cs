using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardManager : MonoBehaviour
{
    public Text questName;
    public GameObject questRewardUI;

    public QuestBase quest;

    public Collectible[] collectibles;
    public InfoCards[] infoCardsConstellations;

    private PlayerManager playerManager;

    public void Start()
    {
        // SetRewardUI(quest);
        playerManager = GameManager.instance.playerManager;
    }

    public void ClaimRewards(QuestBase quest)
    {
        AudioManager.instance.PlaySFX("Reward");
        string rewards = '"' + quest.name + "\" Completed\n";
        Debug.Log("I got a reward" + collectibles.Length + " " + quest.rewards.collectibles.Length);
        playerManager.playerProfile.playergold += quest.rewards.goldReward;
        playerManager.playerProfile.currentXP += quest.rewards.xpReward;
        rewards += "You received " + (quest.rewards.goldReward == 0 ? "" : quest.rewards.goldReward) + " Gold\n";
        rewards += "You received " + (quest.rewards.xpReward == 0 ? "" : quest.rewards.xpReward) + " XP";

        for (int i = 0; i < collectibles.Length; i++)
        {
            for (int j = 0; j < quest.rewards.collectibles.Length; j++)
            {
                if (collectibles[i].name == quest.rewards.collectibles[j].name)
                {
                    collectibles[i].isUnlockCollectible = true;
                    rewards += "\nYou received " + collectibles[i].name + " Information";
                    Debug.Log("I get a collectible reward");
                }
            }
        }
        GameManager.instance.PopUpNotification(rewards);
    }


}
