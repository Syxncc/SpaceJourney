using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{

    public QuestSequence questSequence;
    public Profile playerProfile;
    public GameObject playerBody;
    public PlayerController playerController;
    // public string userName;

    private int addMaxXP = 100;
    private int tempXP;

    public Text blueGemText;
    public Text greenGemText;
    public Text redGemText;
    public Text currentGoldText;
    public Text PlayerNameText;
    public Text PlayerLevelText;
    public Text xpText;

    public Slider xpBar;
    public StoryImages storyImages;
    public TextAsset story;

    public ShipConttrol shipControl;
    [SerializeField]
    TMP_Text walkTextUI, sprintTextUI, jumpTextUI, jumpStaminaTextUI, sprintStaminaTextUI, boostTextUI, spaceshipSpeedTextUI, bulletOverheatingTextUI;

    void Start()
    {
        // playerProfile.currentXP = 0;
        xpBar.maxValue = playerProfile.currentMaxXP;
        xpBar.value = playerProfile.currentXP;
        if (QuestManager.instance != null)
        {
            if (GameManager.instance.playerQuest.isNewGame)
            {
                GameManager.instance.playerQuest.isNewGame = false;
                GameManager.instance.playerQuest.isQuestDone = false;
                QuestManager.instance.SetQuestUI(GameManager.instance.playerQuest.questSequence[0]);
                DialMan.instance.EnterDialogueMode(story, storyImages, null);
            }
            else
            {
                QuestSequence playerQuest = GameManager.instance.playerManager.questSequence;
                if ((playerQuest.currentQuestIndex) < playerQuest.questSequence.Length)
                {
                    QuestManager.instance.CurrentQuest = GameManager.instance.playerQuest.questSequence[GameManager.instance.playerQuest.currentQuestIndex];
                }
                else
                {
                    playerQuest.isQuestDone = true;
                }
            }
        }
    }

    void Update()
    {
        PlayerLevelText.text = playerProfile.playerLevel.ToString();
        xpText.text = playerProfile.currentXP.ToString() + " / " + playerProfile.currentMaxXP.ToString();
        currentGoldText.text = playerProfile.playergold.ToString();
        blueGemText.text = playerProfile.playerbluegem.ToString();
        redGemText.text = playerProfile.playerredgem.ToString();
        greenGemText.text = playerProfile.playergreengem.ToString();
        PlayerNameText.text = playerProfile.name;

        if (playerProfile.currentXP >= playerProfile.currentMaxXP)
        {
            tempXP = playerProfile.currentXP - playerProfile.currentMaxXP;
            playerProfile.currentXP = tempXP;
            playerProfile.playerLevel++;
            IncreaseMaxXP();
        }

        xpBar.maxValue = playerProfile.currentMaxXP;
        xpBar.value = playerProfile.currentXP;
    }

    public void IncreaseMaxXP()
    {
        playerProfile.currentMaxXP += addMaxXP;
        addMaxXP += 50;
    }

    public void GetStats()
    {
        walkTextUI.text = playerProfile.upgrade.walk.ToString();
        sprintTextUI.text = playerProfile.upgrade.sprint.ToString();
        jumpTextUI.text = playerProfile.upgrade.jump.ToString();
        sprintStaminaTextUI.text = playerProfile.upgrade.sprintStamina.ToString();
        jumpStaminaTextUI.text = playerProfile.upgrade.jumpStamina.ToString();
        boostTextUI.text = playerProfile.upgrade.boost.ToString();
        spaceshipSpeedTextUI.text = playerProfile.upgrade.spaceshipSpeed.ToString();
        bulletOverheatingTextUI.text = playerProfile.upgrade.bulletOverheating.ToString();
    }

}
