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
    private DialTrig trig;
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
            trig = other.gameObject.GetComponent<DialTrig>();
            questGive = other.gameObject.GetComponent<QuestGiver>();
            inkJSONS = trig.inkJSON;
            nonPlayerName.text = trig.noName;
            Debug.Log(inkJSONS);
            shop = trig.shop;
            
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "NPC"){
        
        }
    }

    public void BtnIsPressed(){
        DialMan.GetInstance().EnterDialogueMode(inkJSONS);

        if (trig.aDialogueQuest){
            questGive.AcceptQuest();
        }

        if(player.quest.isActive){
            player.CheckTalk(player.quest.goal.targetNPCTalk, trig.noName);
        }
    }


}
