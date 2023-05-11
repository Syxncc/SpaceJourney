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

    public delegate void OnItemDestroyCallback(Profile item);
    public OnItemDestroyCallback onItemDestroyCallback;

    public RewardManager rewardManager;
    public PlayerManager playerManager;
    public ShopManager shopManager;
    public GameObject loadingScene;


    public GameObject notification;
    private Animator notificationAnimator;
    private TMP_Text notificationText;

    public QuestSequence playerQuest;
    public Collectible[] collectibles;
    public CountdownTimer countdownTimer;
    public Profile player;
    public string title;
    public string message;

    public Animator changeSceneAnimator;
    public GameObject textShow;

    public GameObject tutorialSpace;

    void Start()
    {
        if (playerQuest.isNewGame || SceneManager.GetActiveScene().buildIndex == 7)
        {
            Debug.Log("New Game Initiated!!!");
            GameManager.instance.player.currentScene = -1;
        }
        if (player != null && SceneManager.GetActiveScene().buildIndex != 0)
        {
            bool isInSpace = false;
            if (player.currentScene != -1 && !playerQuest.isTravel || SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    player.currentScene = 2;
                    Debug.Log("I am inpsace");
                    isInSpace = true;

                    if (tutorialSpace != null && player.firstTimeInGameScene)
                    {
                        tutorialSpace.gameObject.SetActive(true);
                        player.firstTimeInGameScene = false;
                    }
                }
                if (playerManager != null)
                {
                    print("SPAWNMING");
                    StartCoroutine(delaySpawn(isInSpace, 1f));
                }
                // if (SceneManager.GetActiveScene().buildIndex != player.currentScene)
                // {
                //     print("SADD");
                //     // SceneManager.LoadScene(player.currentScene);
                //     ChangeScene(player.currentScene);
                // }
            }
            else
            {
                playerQuest.isTravel = false;
            }



            if (notification != null)
            {
                notificationAnimator = notification.GetComponent<Animator>();
                notificationText = notification.GetComponent<TMP_Text>();
            }
        }
        if (AudioManager.instance != null)
        {
            AudioManager.instance.sfxSlider.value = player.sfxVolume;
            AudioManager.instance.musicSlider.value = player.musicVolume;
        }
        countdownTimer = GetComponent<CountdownTimer>();

    }

    IEnumerator delaySpawn(bool isInSpace, float waitTime)
    {
        loadingScene.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        loadingScene.SetActive(false);
        playerManager.playerBody.transform.position = player.CharacterPosition(isInSpace);
    }

    void OnApplicationQuit()
    {
        // SaveCurrentCharacterPosition();
        Debug.Log("Game Saved");

        SaveCurrentCharacterPosition();
    }

    // void OnApplicationQuit()
    // {
    //     Debug.Log("Quitting");
    //     SaveSystem.SaveScriptableObject(player, player.name);
    //     SaveSystem.SaveScriptableObject(playerQuest, playerQuest.name);
    //     foreach (Collectible collectible in collectibles)
    //     {
    //         SaveSystem.SaveScriptableObject(collectible, collectible.name);
    //     }
    // }

    public void PopUpNotification(string message)
    {
        notificationText.text = message;
        notificationAnimator.SetTrigger("rewarded");
    }

    public void RestartGame()
    {
        player.currentScene = 1;
        playerQuest.currentQuestIndex = 0;
        playerQuest.isQuestDone = false;
        player.firstTimeInGameScene = true;
        ResetPlayerStats();
        player.spacePositionX = 0;
        foreach (Collectible collectible in collectibles)
        {
            // if (collectible.GetType().ToString() != "Collectible")
            // {
            collectible.isUnlockCollectible = true;
            // }
            // else
            // {
            //     collectible.isUnlockCollectible = false;
            // }
        }
    }

    void ResetPlayerStats()
    {
        player.playergold = 10000;
        player.positionX = -566.6966f;
        player.positionY = -21.37539f;
        player.positionZ = 106.1419f;
        player.playerbluegem = 1;
        player.playergreengem = 5;
        player.playerredgem = 10;
        player.playerLevel = 1;
        player.currentMaxXP = 100;
        player.currentXP = 0;
        player.jumpHeight = 3f;
        player.walkingSpeed = 7f;
        player.sprintingSpeed = player.walkingSpeed * 2;
        player.regenCost = 5f;
        player.decreaseCostOvertime = 15f;
        player.jumpCost = 10f;
        player.maxStamina = 100f;
        player.thrustBoosted = 3f;
        player.boostStaminaCost = 20f;
        player.firingStaminaCost = 30f;
        player.musicVolume = .5f;
        player.sfxVolume = .5f;
        player.upgrade.walk = 5;
        player.upgrade.sprint = 5;
        player.upgrade.jump = 5;
        player.upgrade.jumpStamina = 5;
        player.upgrade.sprintStamina = 5;
        player.upgrade.spaceshipSpeed = 5;
        player.upgrade.boost = 5;
        player.upgrade.bulletOverheating = 5;
    }

    public bool isDoneAllQuest()
    {
        return playerQuest.isQuestDone;
    }

    public void ChangeScene(int sceneIndex)
    {
        // ui.SetActive(false);
        float waitTime = 0f;
        if (changeSceneAnimator != null)
        {
            waitTime = .7f;
            changeSceneAnimator.SetTrigger("changeScene");
        }
        StartCoroutine(delayChangeScene(sceneIndex, waitTime));

    }

    IEnumerator delayChangeScene(int sceneIndex, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        loadingScene.SetActive(true);
        if (sceneIndex != -1)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
            // playerQuest.isTravel = true;
        }
        else
        {
            Debug.Log("RESTART");
            AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SaveCurrentCharacterPosition()
    {
        if (player != null)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            if (currentScene == 1 || currentScene == 2 || currentScene == 3)
            {
                print("SAve position");
                if (playerManager != null)
                {
                    player.currentScene = SceneManager.GetActiveScene().buildIndex;
                    Vector3 playerPosition = playerManager.playerBody.transform.position;
                    if (player.currentScene != 2)
                    {
                        player.positionX = playerPosition.x;
                        player.positionY = playerPosition.y;
                        player.positionZ = playerPosition.z;
                    }
                    else
                    {
                        player.spacePositionX = playerPosition.x;
                        player.spacePositionY = playerPosition.y;
                        player.spacePositionZ = playerPosition.z;
                    }
                }
                player.ToJson();

            }
            playerQuest.ToJson();
            foreach (Collectible collectible in collectibles)
            {
                collectible.ToJson();
            }
        }

    }

    public void IncreaseCount()
    {
        if (countdownTimer != null && countdownTimer.timerIsRunning)
        {
            countdownTimer.tempTimer += 1;
            countdownTimer.tempCount += 1;
        }
    }

    public void ChangeMessagePopupPanel(bool popup, QuestBase quest, bool isLose)
    {
        if (countdownTimer != null)
        {
            Debug.Log(popup);
            if (quest != null)
            {
                if (quest.isQuestTimerObjective && QuestManager.instance.CompareQuest(quest, -1))
                {
                    popup = true;
                    Debug.Log("Popup");
                }
            }
            if (popup)
            {
                countdownTimer.ValidateCurrentHighScore(isLose);
                if (isLose)
                {
                    countdownTimer.isStart = true;
                }
            }
        }
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToHomeScreen()
    {
        SaveCurrentCharacterPosition();
        ChangeScene(0);
    }

    public void UnlockCollectible(Planet planet)
    {
        planet.isUnlockCollectible = true;
    }

}
