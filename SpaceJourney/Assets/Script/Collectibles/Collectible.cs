using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectible", menuName = "ScriptableObject/Collectible")]
public class Collectible : ScriptableObject
{
    public string name = "";
    public bool isUnlockCollectible = false;
    public ConstellationDotProfile[] constellationDotProfiles;
    private void OnValidate()
    {
        name = System.IO.Path.GetFileNameWithoutExtension(UnityEditor.AssetDatabase.GetAssetPath(this));
    }
}
