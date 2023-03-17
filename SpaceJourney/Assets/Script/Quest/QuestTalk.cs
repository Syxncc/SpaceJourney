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
        Debug.Log("Quest Started!");
        for (int i = 0; i < objectives.Length; i++)
        {
            RequiredAmount[i] = objectives[i].requiredAmount;
        }
        GameManager.instance.onTalkNPCCallback += TalkNPC;
        base.InitializeQuest();
        SetObjectives(GetAllObjectives());
    }

    private string GetAllObjectives()
    {
        string data = "";
        for (int i = 0; i < objectives.Length; i++)
        {
            Objectives item = objectives[i];
            data += "- Talk to " + item.requiredProfile.name + " (" + (CurrentAmount[i]) + "/" + item.requiredAmount + ")\n";
        }

        return data;
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
        Debug.Log("Yow");
        SetObjectives(GetAllObjectives());
        Evaluate(true);
    }
}
