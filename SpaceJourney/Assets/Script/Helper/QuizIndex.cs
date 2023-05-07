using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizIndex : MonoBehaviour
{
    private QuestSequence playerQuest;
    void Start()
    {
        playerQuest = GameManager.instance.playerQuest;
    }
    public void SetQuizIndex(int quizIndex)
    {
        if (quizIndex == -2)
        {
            playerQuest.isQuestDone = true;
        }
        else
        {
            playerQuest.currentQuestIndex = quizIndex;
        }
    }
}
