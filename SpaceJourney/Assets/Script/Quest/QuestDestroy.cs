using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Destroy Quest", menuName = "ScriptableObject/Quests/Destroy Quest")]
public class QuestDestroy : QuestBase
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

        for (int i = 0; i < objectives.Length; i++)
        {
            RequiredAmount[i] = objectives[i].requiredAmount;
        }
        if (GameManager.instance.onItemDestroyCallback == null)
        {
            GameManager.instance.onItemDestroyCallback += ItemDestroy;
        }
        base.InitializeQuest();
        SetObjectives(GetAllObjectives());
    }

    private string GetAllObjectives()
    {
        string data = "";
        for (int i = 0; i < objectives.Length; i++)
        {
            Objectives item = objectives[i];
            data += "- Destroy " + item.requiredProfile.name + " (" + (CurrentAmount[i]) + "/" + item.requiredAmount + ")\n";
        }

        return data;
    }

    private void ItemDestroy(Profile destroyedItem)
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            if (destroyedItem == objectives[i].requiredProfile)
            {
                CurrentAmount[i]++;
            }
        }
        SetObjectives(GetAllObjectives());
        Evaluate(false);
    }
}
