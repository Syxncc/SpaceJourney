using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    
    public string userName;

    public static int playergold = 10000;
    public static int playerbluegem = 1;
    public static int playergreengem = 5;
    public static int playerredgem = 10;
    
    public float jumpHeight = 0.7f;
    public float walkingSpeed = 10f;
    public float sprintingSpeed = 20f;
    public float regenCost = 5f;
    public float decreaseCostOvertime = 15f;
    public float jumpCost = 10f;
    public static float maxStamina = 100f;

    public static float thrustBoosted = 3f;
    public static float boostStaminaCost = 20f;
    public static float firingStaminaCost = 30f;

    public Text blueGemText;
    public Text greenGemText;
    public Text redGemText;
    public Text currentGoldText;
    public Text PlayerNameText;

    

    void Update()
    {
        currentGoldText.text = playergold.ToString();
        blueGemText.text = playerbluegem.ToString();
        redGemText.text = playerredgem.ToString();
        greenGemText.text = playergreengem.ToString();
        PlayerNameText.text = userName;

    }

    public void SpaceScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void LabScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

}
