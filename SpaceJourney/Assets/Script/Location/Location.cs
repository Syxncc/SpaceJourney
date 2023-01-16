using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "ScriptableObject/Location")]
public class Location : ScriptableObject
{
    public string name = "";
    public bool hideOnComplete = false;
    private void OnValidate()
    {
        name = System.IO.Path.GetFileNameWithoutExtension(UnityEditor.AssetDatabase.GetAssetPath(this));
    }
}
