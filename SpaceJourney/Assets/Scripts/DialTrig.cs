using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialTrig : MonoBehaviour
{
    [SerializeField]
    private GameObject interactbtn;

    private bool playerInRange;

    [Header("Ink JSON")]
    [SerializeField] 
    private TextAsset inkJSON;
    
    private void Awake(){
        playerInRange = false;
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerInRange);
        if (playerInRange){
            interactbtn.SetActive(true);
        }
        else {
            interactbtn.SetActive(false);
        }
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

    
}
