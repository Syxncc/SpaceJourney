using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "Collectible", menuName = "ScriptableObject/Collectible")]
public class Collectible : ScriptableObject
{
    public string name = "";
    public bool isUnlockCollectible = false;
    public ConstellationDotProfile[] constellationDotProfiles;

#if UNITY_EDITOR
    private void OnValidate()
    {
        name = System.IO.Path.GetFileNameWithoutExtension(UnityEditor.AssetDatabase.GetAssetPath(this));
    }
#endif

    public void ToJson()
    {
        string json = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/" + this.name + ".json", json);
    }

    public static T LoadFromJSON<T>(string filename) where T : Collectible
    {
        string path = Application.persistentDataPath + "/" + filename + ".json";
        if (File.Exists(path))
        {
            string jsonString = System.IO.File.ReadAllText(path);
            T obj = ScriptableObject.CreateInstance<T>();
            JsonUtility.FromJsonOverwrite(jsonString, obj);
            return obj;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
