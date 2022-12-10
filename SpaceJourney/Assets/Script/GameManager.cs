using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public delegate void OnTalkNPCCallback(Profile profile);
    public OnTalkNPCCallback onTalkNPCCallback;

    public delegate void OnDestinationCallback(Location profile);
    public OnDestinationCallback onDestinationCallback;

    public delegate void OnPushCallback(Profile profile);
    public OnPushCallback onPushCallback;

    public RewardManager rewardManager;
    public PlayerManager playerManager;
    public ShopManager shopManager;
    public GameObject loadingScene;


    public GameObject notification;
    private Animator notificationAnimator;
    private TMP_Text notificationText;

    public QuestSequence playerQuest;
    public Collectible[] collectibles;
    public Profile player;

    void Start()
    {
        if (notification != null)
        {
            notificationAnimator = notification.GetComponent<Animator>();
            notificationText = notification.GetComponent<TMP_Text>();
        }
    }

    public void PopUpNotification(string message)
    {
        notificationText.text = message;
        notificationAnimator.SetTrigger("rewarded");
    }

    public void RestartGame()
    {
        playerQuest.currentQuestIndex = 0;
        playerQuest.isQuestDone = false;
        ResetPlayerStats();
        foreach (Collectible collectible in collectibles)
        {
            collectible.isUnlock = false;
        }
    }

    void ResetPlayerStats()
    {
        player.playergold = 10000;
        player.playerbluegem = 1;
        player.playergreengem = 5;
        player.playerredgem = 10;
        player.playerLevel = 1;
        player.currentMaxXP = 100;
        player.currentXP = 0;
        player.jumpHeight = 0.7f;
        player.walkingSpeed = 10f;
        player.sprintingSpeed = 20f;
        player.regenCost = 5f;
        player.decreaseCostOvertime = 15f;
        player.jumpCost = 10f;
        player.maxStamina = 100f;
        player.thrustBoosted = 3f;
        player.boostStaminaCost = 20f;
        player.firingStaminaCost = 30f;
    }

    public bool isDoneQuest()
    {
        return playerQuest.isQuestDone;
    }

    public void ChangeScene()
    {
        // ui.SetActive(false);
        Debug.LogError("Launching");
        loadingScene.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
