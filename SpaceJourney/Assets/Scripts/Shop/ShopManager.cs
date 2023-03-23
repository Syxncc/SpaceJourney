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
    private Profile playerProfile;

    void Start()
    {
        playerProfile = GameManager.instance.playerManager.playerProfile;
    }

    // Update is called once per frame
    void Update()
    {
        goldtxt.text = playerProfile.playergold.ToString();
        bluetxt.text = playerProfile.playerbluegem.ToString();
        greentxt.text = playerProfile.playergreengem.ToString();
        redtxt.text = playerProfile.playerredgem.ToString();

    }
    // public void DeductPrice(int gearPrice){
    //     Debug.Log("DEDUCTED");
    //     playerProfile.playergold -= gearPrice;
    //     Debug.Log(playerProfile.playergold);
    // }


    public void increaseWalkSpeed()
    {
        playerProfile.upgrade.walk += 1;
    }

    public void increaseSprintingSpeed()
    {
        // playerProfile.sprintingSpeed += 1f;
        playerProfile.upgrade.sprint += 1;
    }

    public void increaseJumpHeight()
    {
        playerProfile.upgrade.jump += 1;
    }

    public void decreaseStaminaSprint()
    {
        // playerProfile.decreaseCostOvertime -= 0.5f;
        playerProfile.upgrade.sprintStamina += 1;
    }

    public void decreaseStaminaJump()
    {
        // playerProfile.jumpCost -= 0.2f;
        playerProfile.upgrade.jumpStamina += 1;
    }

    public void incnreaseBoostPower()
    {
        // playerProfile.thrustBoosted -= 0.2f;
        playerProfile.upgrade.spaceshipSpeed += 1;
    }

    public void decreaseBoostStaminaCost()
    {
        // playerProfile.boostStaminaCost -= 1f;
        playerProfile.upgrade.boost += 1;
    }

    public void decreaseFiringStaminaCost()
    {
        // playerProfile.firingStaminaCost -= 2f;
        playerProfile.upgrade.bulletOverheating += 1;
    }

    public void deductGem(string gemType, int quantity)
    {
        if (gemType == "Blue")
        {
            playerProfile.playerbluegem -= quantity;
        }
        else if (gemType == "Green")
        {
            playerProfile.playergreengem -= quantity;
        }
        else if (gemType == "Red")
        {
            playerProfile.playerredgem -= quantity;
        }
    }

    public void tradeToGold(int tradingPrice)
    {
        playerProfile.playergold += tradingPrice;
    }
}
