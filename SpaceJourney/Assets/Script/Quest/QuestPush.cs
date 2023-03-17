using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Push Quest", menuName = "ScriptableObject/Quests/Push Quest")]
public class QuestPush : QuestBase
{
    [System.Serializable]
    public class Objectives
    {
        public Profile requiredProfile;
        public int requiredAmount;
        public GameObject box;
        public GameObject destination;
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
        GameManager.instance.onPushCallback += PushObject;
        base.InitializeQuest();
    }

    private void PushObject(Profile npc)
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
