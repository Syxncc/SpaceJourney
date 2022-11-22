using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardUI : MonoBehaviour
{
    
    public GameObject rewardUI;
    
    public void onCollisionEnter(Collision collision){
        
        rewardUI.SetActive(true);
    }
    
}
