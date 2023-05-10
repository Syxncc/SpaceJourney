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


    public void ToJson()
    {
        string json = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/player_quest.json", json);
    }

    public static T LoadFromJSON<T>() where T : QuestSequence
    {
        string path = Application.persistentDataPath + "/player_quest.json";
        string jsonString = System.IO.File.ReadAllText(path);
        T obj = ScriptableObject.CreateInstance<T>();
        JsonUtility.FromJsonOverwrite(jsonString, obj);
        return obj;
    }
}
