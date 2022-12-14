using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Talk Quest", menuName = "ScriptableObject/Quests/Talk Quest")]
public class QuestTalk : QuestBase
{
    [System.Serializable]
    public class Objectives
    {
        public Profile requiredProfile;
        public int requiredAmount;
    }

    public Objectives[] objectives;

    public override void InitializeQuest()
    {
        RequiredAmount = new int[objectives.Length];
        Debug.LogError("Quest Started!");
        for (int i = 0; i < objectives.Length; i++)
        {
            RequiredAmount[i] = objectives[i].requiredAmount;
        }
        GameManager.instance.onTalkNPCCallback += TalkNPC;
        base.InitializeQuest();
    }

    private void TalkNPC(Profile npc)
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            if (npc == objectives[i].requiredProfile)
            {
                CurrentAmount[i]++;
            }
        }
        Evaluate(false);
    }
}
