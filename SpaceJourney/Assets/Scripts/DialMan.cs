using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class DialMan : MonoBehaviour
{
    public GameObject ControlUI;
    
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Story currentStory;

    private bool dialogueIsPlaying;

    private static DialMan instance;


    public static DialMan GetInstance(){
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        //dialoguePlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterDialogueMode(TextAsset inkJSON){
        currentStory = new Story(inkJSON.text);
    }

    
}
