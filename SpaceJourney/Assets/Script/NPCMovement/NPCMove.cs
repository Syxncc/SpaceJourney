using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public Transform target;

    public Transform[] idlePath;
    private bool isIdle = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
        }
        else if (idlePath.Length > 0)
        {
            MoveRandom();
        }
    }

    void MoveRandom()
    {
        if (isIdle)
        {
            int idleTime = Random.Range(0, 60);
            StartCoroutine(IdleTime(idleTime));
        }
        else
        {
            int randomPosition = Random.Range(1, idlePath.Length);
            Transform currentPosition = idlePath[randomPosition - 1];
            if (currentPosition != null)
            {
                navMeshAgent.SetDestination(currentPosition.position);
                if (Vector3.Distance(currentPosition.position, transform.position) < 1)
                {
                    IsIdle();
                }
            }
        }
    }

    IEnumerator IdleTime(float delayTime)
    {
        Debug.LogError("Start Idling");
        // suspend execution for 5 seconds
        yield return new WaitForSeconds(delayTime);
        Debug.LogError("End Idling");
        IsIdle();
    }

    void IsIdle()
    {
        int maxRange = Random.Range(1000, 5000);
        int idleChance = Random.Range(0, maxRange);
        int rangeNum = Random.Range(0, 500);
        int startRange = Random.Range(0, maxRange);
        int endRange = startRange + rangeNum;
        Debug.Log(idleChance + " " + startRange + " " + endRange);
        if (idleChance >= startRange && idleChance <= endRange)
        {
            isIdle = true;
        }
        isIdle = false;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
