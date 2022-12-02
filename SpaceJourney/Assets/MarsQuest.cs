using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsQuest : MonoBehaviour
{
    public GameObject RewardUI;

    
    public void OnTriggerEnter(Collider other) 
    {
        RewardUI.SetActive(true);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
