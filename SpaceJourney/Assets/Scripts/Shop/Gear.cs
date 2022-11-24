using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gear : MonoBehaviour
{
    
    public ClaimReward bank;
    public GameObject [] levelBar;
    public GameObject promptNoCoin;
    public GameObject promptMaxed;
    public Text leveltxt; 
    public Text pricetxt;
    public int price;

    
    private int level;
    private int countBar; 
    
    
    //private float currentSprintingSpeed;
    


    // Start is called before the first frame update
    void Start()
    {
        countBar = 0;
        level = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        leveltxt.text = level.ToString();
        pricetxt.text = price.ToString();
    }

    public void Upgrade() {
        

        //check if the level is maxed
        if (level == 15){
            promptMaxed.SetActive(true);
        }
        else {
            //check if sufficient balance
            if (price > bank.currentGold){
                promptNoCoin.SetActive(true);
            }
            else {
                enableBar();
            }
        }
        
    }

    public void enableBar(){
        level++;
        levelBar[countBar].SetActive(true);
        countBar++;
        bank.currentGold = bank.currentGold - price; 
        
    }

    public void increaseSpeed(){
        GameManager.instance.playerManager.walkingSpeed += 0.5f;
        GameManager.instance.playerManager.sprintingSpeed += 0.5f;
    }

    public void increaseJumpHeight(){
        GameManager.instance.playerManager.jumpHeight += 0.2f;
        //player.jumpHeight = player.jumpHeight + 0.2f;
    }

    public void decreaseStaminaConsumption(){
        GameManager.instance.playerManager.decreaseCostOvertime -= 0.5f;
        GameManager.instance.playerManager.jumpCost -= 0.2f;
    }

    public void increasePower(){

    }
}
