using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake(){
        if(instance == null){
            instance = this;
        }
    }
    public delegate void OnTalkNPCCallback(Profile profile);
    public OnTalkNPCCallback onTalkNPCCallback;

    public delegate void OnPushCallback(Profile profile);
    public OnPushCallback onPushCallback;

    public RewardManager rewardManager;
    public PlayerManager playerManager;
}
