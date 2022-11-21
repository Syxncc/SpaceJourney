using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    [SerializeField] private NPCPath path;

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float distanceThreshold = 0.1f;

    private Animator animator;

    public Transform player;

    private Transform currentPath;

    public DialMan isTalking;

    public bool standby; 

    public GameObject NPCTextName;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        //set Initial position to waypoint
        currentPath = path.GetNextPath(currentPath);
        transform.position = currentPath.position;

        currentPath = path.GetNextPath(currentPath);
        transform.LookAt(currentPath);
        animator.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        NPCTextName.transform.LookAt(player);
        NPCTextName.transform.Rotate(-40,180,0);
        if (standby){
            animator.SetBool("isMoving", false);
        }
        else {
            
            if (isTalking.dialogueIsPlaying == false){
            transform.position = Vector3.MoveTowards(transform.position, currentPath.position, moveSpeed * Time.deltaTime);
                
                if (Vector3.Distance(transform.position, currentPath.position) < distanceThreshold){
                    currentPath = path.GetNextPath(currentPath);
                    transform.LookAt(currentPath);
                    //animator.SetBool("isTalking", false);
                    animator.SetBool("isMoving", true);
                }
            }
            else {
                //animator.SetBool("isTalking", true);
                transform.LookAt(player);
                animator.SetBool("isMoving", false);
            }
        }


        
    }
}
