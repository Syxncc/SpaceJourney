using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarking : MonoBehaviour
{
    public Location location;
    public Profile profile;
    public GameObject questMarking;

    private QuestManager questManager;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void UpdateMarking()
    {
        questManager = QuestManager.instance;
        if (questManager.CurrentQuest != null)
        {
            questMarking?.SetActive(false);
            if (location != null)
            {
                if (questManager.CurrentQuest.GetType() == System.Type.GetType("QuestDestination"))
                {
                    QuestDestination quest = (QuestDestination)questManager.CurrentQuest;
                    for (int i = 0; i < quest.objectives.Length; i++)
                    {
                        if (quest.objectives[i].requiredLocation == location)
                        {
                            questMarking.SetActive(true);
                            return;
                        }
                    }
                }
            }
            else if (profile != null)
            {
                Debug.Log("Plant found");
                if (questManager.CurrentQuest.GetType() == System.Type.GetType("QuestTalk"))
                {
                    Debug.Log("Plant found2");
                    QuestTalk quest = (QuestTalk)questManager.CurrentQuest;
                    for (int i = 0; i < quest.objectives.Length; i++)
                    {
                        Debug.Log(quest.objectives[i].requiredProfile.name + " " + profile.name);
                        if (quest.objectives[i].requiredProfile.name == profile.name)
                        {
                            Debug.Log(quest.CurrentAmount[i] + " " + quest.RequiredAmount[i]);
                            if (quest.CurrentAmount[i] == quest.RequiredAmount[i])
                            {
                                questMarking.SetActive(false);
                            }
                            else
                            {
                                questMarking.SetActive(true);
                            }
                            return;
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
