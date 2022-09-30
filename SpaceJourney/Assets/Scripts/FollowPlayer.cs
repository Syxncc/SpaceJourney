using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public NavMeshAgent NPC;
    public Transform Player;

    public bool follow = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (follow){
            NPC.SetDestination(Player.position);
        }
        
        
        
    }

     void OnCollisionEnter(Collision col){
        
        if (col.gameObject.tag == "Player"){
            follow = false;
        }
    }
}
