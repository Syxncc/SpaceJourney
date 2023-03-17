using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text goldtxt;
    public Text bluetxt;
    public Text greentxt;
    public Text redtxt;

    public static int walkLevel;
    public static int sprintLevel;
    public static int jumpLevel;
    public static int jumpStaminaLevel;
    public static int sprintStaminaLevel;
    public static int boostLevel;
    public static int speedLevel;
    public static int bulletOverheatingLevel;
    private PlayerManager playerManager;

    void Start()
    {
        playerManager = GameManager.instance.playerManager;
    }

    // Update is called once per frame
    void Update()
    {
        goldtxt.text = playerManager.playerProfile.playergold.ToString();
        bluetxt.text = playerManager.playerProfile.playerbluegem.ToString();
        greentxt.text = playerManager.playerProfile.playergreengem.ToString();
        redtxt.text = playerManager.playerProfile.playerredgem.ToString();

    }
    // public void DeductPrice(int gearPrice){
    //     Debug.Log("DEDUCTED");
    //     playerManager.playerProfile.playergold -= gearPrice;
    //     Debug.Log(playerManager.playerProfile.playergold);
    // }


    public void increaseWalkSpeed()
    {
        GameManager.instance.playerManager.playerProfile.walkingSpeed += 0.5f;
    }

    public void increaseSprintingSpeed()
    {
        GameManager.instance.playerManager.playerProfile.sprintingSpeed += 0.5f;
    }

    public void increaseJumpHeight()
    {
        GameManager.instance.playerManager.playerProfile.jumpHeight += 0.2f;
    }

    public void decreaseStaminaSprint()
    {
        GameManager.instance.playerManager.playerProfile.decreaseCostOvertime -= 0.5f;
    }

    public void decreaseStaminaJump()
    {
        GameManager.instance.playerManager.playerProfile.jumpCost -= 0.2f;
    }

    public void incnreaseBoostPower()
    {
        playerManager.playerProfile.thrustBoosted -= 0.2f;
    }

    public void decreaseBoostStaminaCost()
    {
        playerManager.playerProfile.boostStaminaCost -= 1f;
    }

    public void decreaseFiringStaminaCost()
    {
        playerManager.playerProfile.firingStaminaCost -= 2f;
    }

    public void deductGem(string gemType, int quantity)
    {
        if (gemType == "Blue")
        {
            playerManager.playerProfile.playerbluegem -= quantity;
        }
        else if (gemType == "Green")
        {
            playerManager.playerProfile.playergreengem -= quantity;
        }
        else if (gemType == "Red")
        {
            playerManager.playerProfile.playerredgem -= quantity;
        }
    }

    public void tradeToGold(int tradingPrice)
    {
        playerManager.playerProfile.playergold += tradingPrice;
    }
}
