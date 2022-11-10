using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialTrig : MonoBehaviour
{
    [SerializeField]
    private GameObject interactbtn;
    
    public bool hasChoices;
    public int choiceInterval = 0;
    public GameObject choice1;
    public GameObject choice2;
    public Text choice1Txtbx;
    public Text choice2Txtbx;
    public bool choicesActive;

    public string choicetxt1;
    public string choicetxt2;

    public bool aDialogueQuest;
    public bool shop;

    public QuestGiver theQuest;

    public string noName;
    // public Text nonPlayerName;
    // public Player playerInput;
    private bool playerInRange;

    [Header("Ink JSON")]
    [SerializeField] 
    public TextAsset inkJSON;
    
    private void Awake(){
        playerInRange = false;
        // playerInput = new Player();
    }
    
    

    // private void OnEnable(){
    //     playerInput.Enable();
    // }

    // private void OnDisable(){
    //     playerInput.Disable();
    // }
    
    // Start is called before the first frame update
    void Start()
    {
        // nonPlayerName.text = noName;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasChoices){
            choice1Txtbx.text = choicetxt1;
            choice2Txtbx.text = choicetxt2;
        }
        // if (playerInRange){
            
            
        // }
        // else {
            
        // }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){
            
            playerInRange = true;

        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player"){
            
            playerInRange = false;
        }
    }

    // public void BtnIsPressed(){
    //     DialMan.GetInstance().EnterDialogueMode(inkJSON);
    // }
    
}
