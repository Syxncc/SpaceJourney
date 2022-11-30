using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    
    
    public Text nonPlayerName;

    public QuestGiver questGive;
    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "NPC")
        {
            Debug.LogError("NPC");
            
            questGive = other.gameObject.GetComponent<QuestGiver>();
            if(questGive.quest.isCompleted == false){
                trig = other.gameObject.GetComponent<DialTrig>();
                DialMan.instance.trigs = trig;
                inkJSONS = trig.inkJSON;
                nonPlayerName.text = trig.noName;
                Debug.Log(inkJSONS);
                
            }else{
                //Put here dialog that for not quest
                Debug.LogError("Hello I don't have a dialogue");
                trig = other.gameObject.GetComponent<DialTrig>();
                DialMan.instance.trigs = trig;
                inkJSONS = trig.inkJSON;
                nonPlayerName.text = trig.noName;
            }
            //DialMan.GetInstance().GetChoice(trig);
            
        }
        else if (other.tag == "TradeNPC"){
            Debug.LogError("TradeNPC");
            isTradeNPC = true;

        }
        else if (other.tag == "UpgradeNPC"){
            Debug.LogError("UpgradeNPC");
            isUpgradeNPC = true;
        }
        else if (other.tag == "LaunchNPC"){
            Debug.LogError("LaunchNPC");
            isLaunch = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        isTradeNPC = false;
        isUpgradeNPC = false;
    }


    public void BtnIsPressed(){
        


        if (isTradeNPC){
            shopUI.ShowTradeUI();
        }
        else if (isUpgradeNPC){
            shopUI.ShowUpgradeUI();
        }
        else if (isLaunch){
            Debug.LogError("Launching");
            loadingScene.SetActive(true);
            AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
            isLaunch = false;
        }
        else {
            DialMan.instance.EnterDialogueMode(inkJSONS);
        

            if (trig.aDialogueQuest){
                DialMan.instance.SetQuest(questGive.quest);
            }

            // if(player.quest.isActive){
            //     player.CheckTalk(player.quest.goal.targetNPCTalk, trig.noName);
            // }
        }


        
    }


}
