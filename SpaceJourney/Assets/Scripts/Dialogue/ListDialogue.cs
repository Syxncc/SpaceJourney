using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDialogue : MonoBehaviour
{
     void Start() {
        List<Transform> children = GetChildren(transform);

        foreach (Transform child in children){
            child.gameObject.SetActive(false);
        }
    }

    List<Transform> GetChildren(Transform parent){
        List<Transform> children = new List<Transform>();
        foreach (Transform child in children){
            children.Add(child);
        }
        return children;
    }
    
    
    



}

