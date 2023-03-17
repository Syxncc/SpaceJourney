using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeDialogue : MonoBehaviour
{
    public TextAsset questDialogue;
    public GameObject questObject;
    public GameObject startPanel;
    public QuestBase planetQuest;
    // Start is called before the first frame update
    void Start()
    {
        if (QuestManager.instance.CompareQuest(planetQuest, 0))
        {
            planetQuest.InitializeQuest();
            DialMan.instance.SetQuest(planetQuest);
        }
        DialMan.instance.EnterDialogueMode(questDialogue, null, questObject);
    }

    public void SetActiveObject()
    {
        questObject.SetActive(false);
    }
}
