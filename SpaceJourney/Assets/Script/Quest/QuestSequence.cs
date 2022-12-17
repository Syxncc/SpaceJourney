using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest Sequnce", menuName = "ScriptableObject/Quests/Sequence")]
public class QuestSequence : ScriptableObject
{
    public bool isNewGame = false;
    public bool isTravel = false;
    public int currentQuestIndex;
    public QuestBase[] questSequence;
    public bool isQuestDone;
}
