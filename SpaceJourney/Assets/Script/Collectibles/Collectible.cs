using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectible", menuName = "ScriptableObject/Collectible")]
public class Collectible : ScriptableObject
{
    public string name = "";
    public bool isUnlock = false;
}
