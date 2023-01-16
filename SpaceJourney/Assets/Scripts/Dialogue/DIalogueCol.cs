using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class DIalogueCol : MonoBehaviour
{

    public ShopUIButton shopUI;
    public GameObject UI;
    public GameObject loadingScene;
    public PlayerController player;

    private TextAsset inkJSONS;
    public DialTrig trig;
    private bool isTradeNPC = false;
    private bool isUpgradeNPC = false;
    private bool isLaunch = false;


    public TMP_Text nonPlayerName;
    private QuestSequence playerQuest;

    public QuestGiver questGive;




    // Start is called before the first frame update
    void Start()
    {
        playerQuest = GameManager.instance.playerManager.questSequence;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            // Debug.LogError("NPC");

            questGive = other.gameObject.GetComponent<QuestGiver>();
            trig = other.gameObject.GetComponent<DialTrig>();
            DialMan.instance.trigs = trig;
            nonPlayerName.text = trig.npcName;
            if (questGive != null && playerQuest.questSequence.Length > playerQuest.currentQuestIndex && playerQuest.questSequence[playerQuest.currentQuestIndex].GetType() != System.Type.GetType("QuestDestination") && (questGive.CurrentQuest() || haveQuestTalk((QuestTalk)playerQuest.questSequence[playerQuest.currentQuestIndex], trig.profile)))
            {
                // trig = other.gameObject.GetComponent<DialTrig>();
                DialMan.instance.SetQuest(questGive.quest);
                inkJSONS = trig.inkJSON;
                Debug.Log(inkJSONS);

            }
            else
            {
                //Put here dialog that for not quest
                DialMan.instance.SetQuest(null);
                inkJSONS = trig.defaultDialogue;
            }
            if (trig.isEvaluateTimer)
            {
                GameManager.instance.ChangeMessagePopupPanel(true, null, true);
            }

        }
        else if (other.tag == "TradeNPC")
        {
            isTradeNPC = true;

        }
        else if (other.tag == "UpgradeNPC")
        {
            isUpgradeNPC = true;
        }
    }

    private bool haveQuestTalk(QuestTalk quests, Profile npcProfile)
    {
        for (int i = 0; i < quests.objectives.Length; i++)
        {
            if (quests.objectives[i].requiredProfile.name == npcProfile.name)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerExit(Collider other)
    {
        isTradeNPC = false;
        isUpgradeNPC = false;
    }


    public void BtnIsPressed()
    {


        UI.SetActive(false);

        if (isTradeNPC)
        {
            if (shopUI != null)
            {
                shopUI.ShowTradeUI();
            }
        }
        else if (isUpgradeNPC)
        {
            if (shopUI != null)
            {
                shopUI.ShowUpgradeUI();
            }
        }
        else
        {
            if (inkJSONS != null)
            {
                DialMan.instance.dialogueUI.SetActive(true);
                UI.SetActive(false);
                DialMan.instance.EnterDialogueMode(inkJSONS, null, null);
            }
            else
            {
                UI.SetActive(true);
            }
            // else{

            // }


            // if (trig.aDialogueQuest){
            //     DialMan.instance.SetQuest(questGive.quest);
            // }

            // if(player.quest.isActive){
            //     player.CheckTalk(player.quest.goal.targetNPCTalk, trig.noName);
            // }
        }



    }


}
