using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class DialMan : MonoBehaviour
{
   
    public static DialMan instance;
    private QuestBase quest;

    public GameObject ControlUI;
    public Animator animator;

    public GameObject shopUI;
    
    public DIalogueCol collector;
    public DialTrig trigs;

    private bool isPressed;
    public Text dialogueText;

    private Story currentStory;

    public bool dialogueIsPlaying{get; private set;}

    public QuestBase CompleteQuest {get;set;}
    //public NPCMover NPCMover;

    // [SerializeField]
    // private GameObject[] choices;
    // private Text[] choicesText;

    public void SetQuest(QuestBase quest){
        this.quest = quest;
    }
    private void Awake(){
        if (instance == null){
            instance = this;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        dialogueIsPlaying = false;
        isPressed = false;
        
        

        // choicesText = new Text[choices.Length];
        // int index = 0;
        // foreach(GameObject choice in choices){
        //     choicesText[index] = choice.GetComponentInChildren<Text>();
        //     index++;
        // }
    }

    // Update is called once per frame
    void Update()
    {

        
        //return right away if dialogue isn't playing
        if (!dialogueIsPlaying){
            return;
        }

        if(isPressed){
            
            ContinueStory();
            isPressed = false;
        }
        
        
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        if(GameManager.instance.onTalkNPCCallback != null) {
            GameManager.instance.onTalkNPCCallback.Invoke(trigs.profile);
        }
        animator.SetBool("isOpen", true);
        
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        
        ContinueStory();
    }

    private void ExitDialogueMode(){
        if(quest != null){
            QuestManager.instance.SetQuestUI(quest);
            ControlUI.SetActive(false);
        }
        else {
            ControlUI.SetActive(true);
        }
        
        animator.SetBool("isOpen", false);
        dialogueIsPlaying = false;
        

        if(collector.shop){
            shopUI.SetActive(true);
            ControlUI.SetActive(false);
        }

        
    }

    public void ContinueStory(){
        

        
        if (currentStory.canContinue){

            dialogueText.text = currentStory.Continue();
            
            
        }
        else {
            dialogueIsPlaying = false;
            ExitDialogueMode();
        }
        
    }

    

    public void ConIsPressed(){
       
        isPressed = true;
        
    }

    // public void ChoiceHasSelected (){
    //     trigs.choicesActive = false;
    //     isPressed = true;
    //     trigs.choice1.SetActive(false);
    //     trigs.choice2.SetActive(false);
    // }

    // public void GetChoice(DialTrig trig){
    //     trigs = trig;
    // }

    // private void DisplayChoices(){
    //     List<Choice> currentChoices = currentStory.currentChoices;

    //     if(currentChoices.Count > choices.Length){
    //         Debug.LogError("More choices were given");
    //     }

    //     int index = 0;

    //     foreach(Choice choice in currentChoices){
    //         choices[index].gameObject.SetActive(true);
    //         choicesText[index].text = choice.text;
    //         index++;
    //     }

    //     for (int i = index; i <choices.Length; i++){
    //         choices[i].gameObject.SetActive(false);
    //     }
    // }

    // private void OnTriggerEnter(Collider other) {
    //     if (other.tag == "NPC"){
    //         NPCMover = other.gameObject.GetComponent<NPCMover>();
            
            
    //     }
    // }
}
