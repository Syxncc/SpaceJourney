using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class DialMan : MonoBehaviour
{
    public GameObject ControlUI;
    public Animator animator;

    public GameObject shopUI;
    
    public DIalogueCol collector;
    public DialTrig trigs;

    private bool isPressed;
    public Text dialogueText;

    private Story currentStory;

    public bool dialogueIsPlaying{get; private set;}

    private static DialMan instance;

    private int intervalCounter;

    // [SerializeField]
    // private GameObject[] choices;
    // private Text[] choicesText;


    private void Awake(){
        if (instance != null){
            Debug.LogWarning("Found more than one Dial Man");
        }
        instance = this;
    }

    public static DialMan GetInstance(){
        return instance;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        dialogueIsPlaying = false;
        isPressed = false;
        intervalCounter = 0;
        

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
        animator.SetBool("isOpen", true);
        
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        
        ContinueStory();
    }

    private void ExitDialogueMode(){
        animator.SetBool("isOpen", false);
        dialogueIsPlaying = false;
        ControlUI.SetActive(true);

        if(collector.shop){
            shopUI.SetActive(true);
            ControlUI.SetActive(false);
        }

        
    }

    public void ContinueStory(){
        Debug.Log(intervalCounter);

        
        if (currentStory.canContinue){

            if (intervalCounter == trigs.choiceInterval){
                trigs.choice1.SetActive(true);
                trigs.choice2.SetActive(true);
                trigs.choicesActive = true;
            }
            else {
                dialogueText.text = currentStory.Continue();
            
            }
            
            
            //DisplayChoices();
        }
        else {
            dialogueIsPlaying = false;
            ExitDialogueMode();
        }
        intervalCounter++;
    }

    

    public void ConIsPressed(){
        if (trigs.choicesActive == true){
            isPressed = false;
        }
        else {
            isPressed = true;
        }
        
    }

    public void ChoiceHasSelected (){
        trigs.choicesActive = false;
        isPressed = true;
        trigs.choice1.SetActive(false);
        trigs.choice2.SetActive(false);
    }

    public void GetChoice(DialTrig trig){
        trigs = trig;
    }

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
    
}
