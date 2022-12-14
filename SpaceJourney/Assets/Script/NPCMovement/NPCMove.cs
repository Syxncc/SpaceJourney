using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    public Transform target;

    public Transform[] idlePath;
    private bool isIdle = false;
    Transform currentPosition;
    int randomPosition;

    private float timeLeft = 0;
    public int selectedIdleTime = 5;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (idlePath.Length > 0)
        {
            IsIdle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
            animator.SetBool("isMoving", true);
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
            animator.SetBool("isMoving", false);
            if (timeLeft <= 0)
            {
                int idleTime = Random.Range(3, selectedIdleTime);
                timeLeft = idleTime;
                Debug.LogError(idleTime);
            }
            else
            {
                IdleTime();
            }
        }
        else
        {
            if (currentPosition != null)
            {
                animator.SetBool("isMoving", true);
                if (Vector3.Distance(currentPosition.position, transform.position) <= 6)
                {
                    IsIdle();
                }
                else
                {
                    if (timeLeft < 1)
                    {
                        navMeshAgent.SetDestination(currentPosition.position);
                    }
                }
            }
        }
    }

    void IdleTime()
    {
        timeLeft -= Time.deltaTime;
        Debug.LogError(timeLeft);
        if (timeLeft < 1)
        {
            IsIdle();
        }
    }


    void IsIdle()
    {
        Debug.LogError("Checking Where Going");
        int maxRange = Random.Range(0, 100);
        int idleChance = Random.Range(0, maxRange);
        int rangeNum = Random.Range(50, maxRange);
        int startRange = Random.Range(0, maxRange);
        int endRange = startRange + rangeNum;

        if (idleChance >= startRange && idleChance <= endRange)
        {
            Debug.LogError("Is Idle");
            isIdle = true;
            timeLeft = 0;
            return;
        }
        randomPosition = Random.Range(0, idlePath.Length-1);
        currentPosition = idlePath[randomPosition];
        Debug.LogError("Is going");
        isIdle = false;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
