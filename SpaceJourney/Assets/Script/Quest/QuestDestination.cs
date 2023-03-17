using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Destination Quest", menuName = "ScriptableObject/Quests/Destination Quest")]
public class QuestDestination : QuestBase
{
    [System.Serializable]
    public class Objectives
    {
        public Location requiredLocation;
        public int requiredAmount;
    }

    public Objectives[] objectives;

    public override void InitializeQuest()
    {
        RequiredAmount = new int[objectives.Length];
        Debug.Log("Quest Started! " + this.name);
        for (int i = 0; i < objectives.Length; i++)
        {
            RequiredAmount[i] = objectives[i].requiredAmount;
        }
        GameManager.instance.onDestinationCallback += OnDestination;
        base.InitializeQuest();
        SetObjectives(GetAllObjectives());
    }

    private string GetAllObjectives()
    {
        string data = "";
        for (int i = 0; i < objectives.Length; i++)
        {
            Objectives item = objectives[i];
            data += "- Go to " + item.requiredLocation.name + " (" + (CurrentAmount[i]) + "/" + item.requiredAmount + ")\n";
        }

        return data;
    }

    private void OnDestination(Location location)
    {
        for (int i = 0; i < objectives.Length; i++)
        {
            if (location == objectives[i].requiredLocation)
            {
                CurrentAmount[i]++;
            }
        }
        SetObjectives(GetAllObjectives());
        Evaluate(true);
    }
}
