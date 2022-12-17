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
        questManager = QuestManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (questMarking.activeInHierarchy)
        {
            questMarking.SetActive(false);
        }
        if (questManager.CurrentQuest != null)
        {

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

                if (questManager.CurrentQuest.GetType() == System.Type.GetType("QuestTalk"))
                {
                    QuestTalk quest = (QuestTalk)questManager.CurrentQuest;
                    for (int i = 0; i < quest.objectives.Length; i++)
                    {
                        if (quest.objectives[i].requiredProfile == profile)
                        {
                            questMarking.SetActive(true);
                            return;
                        }
                    }
                }
            }
        }
    }
}
