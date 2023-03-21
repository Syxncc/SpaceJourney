using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    public Transform target;
    public bool isGreedy = false;

    public Transform[] idlePath;
    private bool isIdle = false;
    public Transform currentPosition;
    int randomPosition;
    public float speed = 100f;

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
            if (navMeshAgent == null)
            {
                transform.LookAt(target.position, Vector3.forward);
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                navMeshAgent?.SetDestination(target.position);
            }
            animator?.SetBool("isMoving", true);
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
            animator?.SetBool("isMoving", false);
            if (timeLeft <= 0)
            {
                int idleTime = Random.Range(3, selectedIdleTime);
                timeLeft = idleTime;
                // Debug.Log(idleTime);
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
                animator?.SetBool("isMoving", true);
                if (Vector3.Distance(currentPosition.position, transform.position) <= 6)
                {
                    IsIdle();
                }
                else
                {
                    if (timeLeft < 1)
                    {
                        if (navMeshAgent == null)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, currentPosition.position, speed * Time.deltaTime);
                        }
                        else
                        {
                            navMeshAgent?.SetDestination(currentPosition.position);
                        }
                    }
                }
            }
        }
    }

    void IdleTime()
    {
        timeLeft -= Time.deltaTime;
        // Debug.Log(timeLeft);
        if (timeLeft < 1)
        {
            IsIdle();
        }
    }


    void IsIdle()
    {
        // Debug.Log("Checking Where Going");
        int maxRange = Random.Range(0, 100);
        int idleChance = Random.Range(0, maxRange);
        int rangeNum = Random.Range(50, maxRange);
        int startRange = Random.Range(0, maxRange);
        int endRange = startRange + rangeNum;

        if (idleChance >= startRange && idleChance <= endRange)
        {
            // Debug.Log("Is Idle");
            isIdle = true;
            timeLeft = 0;
            return;
        }
        randomPosition = Random.Range(0, idlePath.Length - 1);
        currentPosition = idlePath[randomPosition];
        // Debug.Log("Is going");
        isIdle = false;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
