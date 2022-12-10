using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public QuestSequence questSequence;
    public Profile playerProfile;
    public GameObject playerBody;
    public PlayerController playerController;
    // public string userName;

    // public int playergold = 10000;
    // public int playerbluegem = 1;
    // public int playergreengem = 5;
    // public int playerredgem = 10;
    // public int playerLevel;

    // public int currentMaxXP = 100;
    // public int currentXP;

    // public float jumpHeight = 0.7f;
    // public float walkingSpeed = 10f;
    // public float sprintingSpeed = 20f;
    // public float regenCost = 5f;
    // public float decreaseCostOvertime = 15f;
    // public float jumpCost = 10f;
    // public float maxStamina = 100f;

    private int addMaxXP = 100;
    private int tempXP;

    // public float thrustBoosted = 3f;
    // public float boostStaminaCost = 20f;
    // public float firingStaminaCost = 30f;

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
                DialMan.instance.EnterDialogueMode(story, storyImages);
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

}
