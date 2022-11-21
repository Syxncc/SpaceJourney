using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPath : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] private float pathSize = 1f;

    public bool oneWay;

    private void OnDrawGizmos() {
        foreach(Transform t in transform){
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, pathSize);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount-1; i++){
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i+1).position);
        }

        
        Gizmos.DrawLine(transform.GetChild(transform.childCount - 1).position, transform.GetChild(0).position);
        
        
    }

    public Transform GetNextPath(Transform currentPath){
        
        if (currentPath == null){
            return transform.GetChild(0);
        }

        if (currentPath.GetSiblingIndex() <  transform.childCount - 1){
            return transform.GetChild(currentPath.GetSiblingIndex() + 1);
        }
        else {
            return transform.GetChild(0);
        }
        
    }
}
