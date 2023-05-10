using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public ProfileSlot[] slot;

    public TMP_Text playerName;

    public GameObject userInputUI;

    public GameObject loadingScene;
    public Slider bar;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        UpdatePlayerData(gameManager.player, Profile.LoadFromJSON<Profile>());
        UpdatePlayerQuest(gameManager.playerQuest, QuestSequence.LoadFromJSON<QuestSequence>());

        foreach (Collectible collectible in gameManager.collectibles)
        {
            collectible.isUnlockCollectible = Collectible.LoadFromJSON<Collectible>(collectible.name).isUnlockCollectible;
        }
    }

    public void CheckSlot()
    {
        // if (){

        // }
    }


    public AsyncOperation operation;

    public void PlayGame(bool isNewGame)
    {
        if (playerName.text != "")
        {
            loadingScene.SetActive(true);
            if (isNewGame)
            {
                gameManager.RestartGame();
                gameManager.playerQuest.isNewGame = true;
                gameManager.player.name = playerName.text;
                operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                operation = SceneManager.LoadSceneAsync(gameManager.player.currentScene);
            }

            StartCoroutine(GetSceneLoadProgress());
        }
    }

    void UpdatePlayerData(Profile player, Profile loadPlayer)
    {
        player.name = loadPlayer.name;
        player.currentScene = loadPlayer.currentScene;
        player.positionX = loadPlayer.positionX;
        player.positionY = loadPlayer.positionY;
        player.positionZ = loadPlayer.positionZ;
        player.spacePositionX = loadPlayer.spacePositionX;
        player.spacePositionY = loadPlayer.spacePositionY;
        player.spacePositionZ = loadPlayer.spacePositionZ;
        player.playergold = loadPlayer.playergold;
        player.playerbluegem = loadPlayer.playerbluegem;
        player.playergreengem = loadPlayer.playergreengem;
        player.playerredgem = loadPlayer.playerredgem;
        player.playerLevel = loadPlayer.playerLevel;
        player.currentMaxXP = loadPlayer.currentMaxXP;
        player.currentXP = loadPlayer.currentXP;
        player.jumpHeight = loadPlayer.jumpHeight;
        player.walkingSpeed = loadPlayer.walkingSpeed;
        player.sprintingSpeed = loadPlayer.sprintingSpeed;
        player.regenCost = loadPlayer.regenCost;
        player.decreaseCostOvertime = loadPlayer.decreaseCostOvertime;
        player.jumpCost = loadPlayer.jumpCost;
        player.maxStamina = loadPlayer.maxStamina;
        player.thrustBoosted = loadPlayer.thrustBoosted;
        player.boostStaminaCost = loadPlayer.boostStaminaCost;
        player.firingStaminaCost = loadPlayer.firingStaminaCost;
        player.musicVolume = loadPlayer.musicVolume;
        player.sfxVolume = loadPlayer.sfxVolume;
        player.upgrade.walk = loadPlayer.upgrade.walk;
        player.upgrade.sprint = loadPlayer.upgrade.sprint;
        player.upgrade.jump = loadPlayer.upgrade.jump;
        player.upgrade.jumpStamina = loadPlayer.upgrade.jumpStamina;
        player.upgrade.sprintStamina = loadPlayer.upgrade.sprintStamina;
        player.upgrade.spaceshipSpeed = loadPlayer.upgrade.spaceshipSpeed;
        player.upgrade.boost = loadPlayer.upgrade.boost;
        player.upgrade.bulletOverheating = loadPlayer.upgrade.bulletOverheating;
    }

    void UpdatePlayerQuest(QuestSequence player, QuestSequence loadPlayer)
    {
        player.currentQuestIndex = loadPlayer.currentQuestIndex;
        player.isQuestDone = loadPlayer.isQuestDone;
    }
    public IEnumerator GetSceneLoadProgress()
    {
        while (!operation.isDone)
        {
            float totalprogress = (operation.progress / .9f);
            bar.value = Mathf.Clamp01(totalprogress);

            yield return null;
        }
    }

    // public void PlayGame (int sceneIndex)
    // {

    //    StartCoroutine(GetSceneLoadProgress(sceneIndex));
    // }
    // public IEnumerator GetSceneLoadProgress(int sceneIndex)
    // {
    //       AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex+1);
    //       loadingScene.SetActive(true);

    //    while (!operation.isDone)
    //    {
    //          float progress = Mathf.Clamp01(operation.progress/ .9f);
    //          bar.value = progress;

    //          yield return null;
    //    }
    // }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void activateProfile()
    {
        //slot.thisFull = true;
    }

    public void deactivateProfile()
    {
        // slot.thisFull = false;
    }



}
