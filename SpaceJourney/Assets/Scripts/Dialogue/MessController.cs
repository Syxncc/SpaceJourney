using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessController : MonoBehaviour
{
    
    public GameObject[] mess;
    
    private int activeIndex = 0;
    
    //private GameObject interactbtn;

    
    

    

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
        if (!(activeIndex == mess.Length)){
            mess[activeIndex].SetActive(true);
            
        }
    } 
        

    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            
        }
    }

    void OnTriggerExit(Collider other){
        
        mess[activeIndex].SetActive(false);
        
        
        if (!(activeIndex == mess.Length)){
            activeIndex++;
        }
    }
}
