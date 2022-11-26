using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayGem : MonoBehaviour
{
    
    public GameObject blueGem;
    public GameObject greenGem;
    public GameObject redGem;

    private bool isVisible = false;

    public void gemBtn(){
        if (isVisible){
            blueGem.SetActive(false);
            greenGem.SetActive(false);
            redGem.SetActive(false);
            isVisible = false;
        }
        else{
            blueGem.SetActive(true);
            greenGem.SetActive(true);
            redGem.SetActive(true);
            isVisible = true;
        }
    }

    
    
}
