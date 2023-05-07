using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAutomatically : MonoBehaviour
{
    public int questIndex = -1;
    private QuestSequence playerQuest;

    public GameObject emptyObject;

    void Start()
    {
        playerQuest = GameManager.instance.playerQuest;
    }

    void Update()
    {
        if (emptyObject.activeInHierarchy) return;
        if (playerQuest.currentQuestIndex == questIndex)
        {
            emptyObject.SetActive(true);
        }
    }
}
