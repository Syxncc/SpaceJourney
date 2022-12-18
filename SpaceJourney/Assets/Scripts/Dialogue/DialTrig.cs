using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialTrig : MonoBehaviour
{
    public Profile profile;
    [SerializeField]
    private GameObject interactbtn;

    // public bool hasChoices;
    // public int choiceInterval = 0;
    // public GameObject choice1;
    // public GameObject choice2;
    // public Text choice1Txtbx;
    // public Text choice2Txtbx;
    // public bool choicesActive;

    // public string choicetxt1;
    // public string choicetxt2;

    public bool aDialogueQuest;
    public bool shop;
    public bool isForLaunching;
    public bool isForSightseeing;

    public QuestGiver theQuest;

    public GameObject RewardUI;
    public GameObject tutorial;

    [HideInInspector]
    public string npcName;
    private bool playerInRange;

    [Header("Ink JSON")]
    [SerializeField]
    public TextAsset inkJSON;
    public TextAsset defaultDialogue;

    private void Awake()
    {
        playerInRange = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        npcName = profile.name;
    }
    // public void rewardUI()
    // {
    //     RewardUI.SetActive(true);
    // }

    public void tutorials()

    {
        if (tutorial != null)
        {
            tutorial.SetActive(true);
        }

    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         // playerInRange = true;
    //         // Debug.LogError("I can talk to npc");
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.tag == "Player")
    //     {
    //         playerInRange = false;
    //     }
    // }

}
