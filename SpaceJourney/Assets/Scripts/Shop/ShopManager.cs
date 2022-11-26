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


    // Update is called once per frame
    void Update()
    {
        goldtxt.text = PlayerManager.playergold.ToString();
        bluetxt.text = PlayerManager.playerbluegem.ToString();
        greentxt.text = PlayerManager.playergreengem.ToString();
        redtxt.text = PlayerManager.playerredgem.ToString();
        
    }
    public void DeductPrice(int gearPrice){
        PlayerManager.playergold -= gearPrice;
    }


    public void increaseWalkSpeed(){
        GameManager.instance.playerManager.walkingSpeed += 0.5f;
    }

    public void increaseSprintingSpeed(){
        GameManager.instance.playerManager.sprintingSpeed += 0.5f;
    }

    public void increaseJumpHeight(){
        GameManager.instance.playerManager.jumpHeight += 0.2f;
    }

    public void decreaseStaminaSprint(){
        GameManager.instance.playerManager.decreaseCostOvertime -= 0.5f;
    }

    public void decreaseStaminaJump(){
        GameManager.instance.playerManager.jumpCost -= 0.2f; 
    }

    public void incnreaseBoostPower(){
        PlayerManager.thrustBoosted -= 0.2f; 
    }

    public void decreaseBoostStaminaCost(){
        PlayerManager.boostStaminaCost -= 1f; 
    }

    public void decreaseFiringStaminaCost(){
        PlayerManager.firingStaminaCost -= 2f; 
    }
    
    public void deductGem(string gemType, int quantity){
        if (gemType == "Blue"){
            PlayerManager.playerbluegem -= quantity;
        }
        else if (gemType == "Green"){
            PlayerManager.playergreengem -= quantity;
        }
        else if (gemType == "Red"){
           PlayerManager.playerredgem -= quantity;
        }
    }

    public void tradeToGold(int tradingPrice){
        PlayerManager.playergold += tradingPrice;
    }
}
