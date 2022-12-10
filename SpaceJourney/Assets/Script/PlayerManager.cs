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
    public static int playerLevel;
    
    public static int currentMaxXP = 100;
    public static int currentXP;
    
    public float jumpHeight = 0.7f;
    public float walkingSpeed = 10f;
    public float sprintingSpeed = 20f;
    public float regenCost = 5f;
    public float decreaseCostOvertime = 15f;
    public float jumpCost = 10f;
    public static float maxStamina = 100f;

    private int addMaxXP = 100;
    private int tempXP;

    public static float thrustBoosted = 3f;
    public static float boostStaminaCost = 20f;
    public static float firingStaminaCost = 30f;

    public Text blueGemText;
    public Text greenGemText;
    public Text redGemText;
    public Text currentGoldText;
    public Text PlayerNameText;
    public Text PlayerLevelText;
    public Text xpText;

    public Slider xpBar;

    void Start(){
        currentXP = 0;
        xpBar.maxValue = currentMaxXP;
        xpBar.value = currentXP;
    }

    void Update()
    {
        PlayerLevelText.text = playerLevel.ToString();
        xpText.text = currentXP.ToString() + " / " + currentMaxXP.ToString();
        currentGoldText.text = playergold.ToString();
        blueGemText.text = playerbluegem.ToString();
        redGemText.text = playerredgem.ToString();
        greenGemText.text = playergreengem.ToString();
        PlayerNameText.text = userName;

        if (currentXP >= currentMaxXP){
            tempXP = currentXP - currentMaxXP;
            currentXP = tempXP;
            playerLevel++;
            IncreaseMaxXP();
        }

        xpBar.maxValue = currentMaxXP;
        xpBar.value = currentXP;
    }

    public void IncreaseMaxXP(){
        currentMaxXP += addMaxXP;
        addMaxXP += 50;
    }

}
