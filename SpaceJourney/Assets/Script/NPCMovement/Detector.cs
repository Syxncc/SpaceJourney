using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    private NPCMove npcMovement;
    void Start()
    {
        npcMovement = transform.GetComponentInChildren<NPCMove>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcMovement.SetTarget(other.transform);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npcMovement.SetTarget(null);
        }
    }
}
