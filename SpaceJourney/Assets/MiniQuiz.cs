using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniQuiz : MonoBehaviour
{
   
   public GameObject quizPanel;
   //public GameObject spaceShip;
   
   public void OnTriggerEnter(Collider other) 
    {
        quizPanel.SetActive(true);
        // if(other == spaceShip)
        // {
            
        // }
    }
}
