using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DIalogueCol : MonoBehaviour
{

    public GameObject shopUI;
    public GameObject UI;
    public PlayerController player;
    
    private TextAsset inkJSONS;
    public DialTrig trig;
    public bool shop;
    
    
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
        if (other.tag == "NPC"){
            questGive = other.gameObject.GetComponent<QuestGiver>();
            if(questGive.quest.isCompleted == false){
                trig = other.gameObject.GetComponent<DialTrig>();
                DialMan.instance.trigs = trig;
                inkJSONS = trig.inkJSON;
                nonPlayerName.text = trig.noName;
                Debug.Log(inkJSONS);
                shop = trig.shop;
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
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "NPC"){
        
        }
    }

    public void BtnIsPressed(){
        DialMan.instance.EnterDialogueMode(inkJSONS);
        

        if (trig.aDialogueQuest){
            DialMan.instance.SetQuest(questGive.quest);
        }

        if(player.quest.isActive){
            player.CheckTalk(player.quest.goal.targetNPCTalk, trig.noName);
        }
    }


}
