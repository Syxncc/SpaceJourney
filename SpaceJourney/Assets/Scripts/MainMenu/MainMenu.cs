using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
      public ProfileSlot[] slot;

      public Text playerName;

      public GameObject userInputUI;

      
      public void CheckSlot(){
         // if (){

         // }
      }




      public void PlayGame (){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
      }

      public void QuitGame (){
        Application.Quit();
      }

      public void activateProfile(){
         //slot.thisFull = true;
      }

      public void deactivateProfile(){
        // slot.thisFull = false;
      }



}
