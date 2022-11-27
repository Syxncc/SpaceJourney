using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gear : MonoBehaviour
{
    
    public GameObject [] levelBar;
    
    public Text pricetxt;
    public int price;

    private int level;
    private int countBar; 
    private int increasePrice = 50;
    
    void Start()
    {
        countBar = 0;
        level = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        pricetxt.text = "Price: " + price.ToString();
    }

    public void Upgrade() {
        

        //check if the level is maxed
        if (level == 5){
            Debug.LogError("Max Level");
            //promptMaxed.SetActive(true);
        }
        else {
            //check if sufficient balance
            if (price > PlayerManager.playergold){
                Debug.LogError("Inssuficient Gold");
                //promptNoCoin.SetActive(true);
            }
            else {
                enableBar();
                //GameManager.instance.shopManager.DeductPrice(price);
                IncreasePrice();
            }
        }
        
    }

    public void enableBar(){
        level++;
        levelBar[countBar].SetActive(true);
        countBar++;
        PlayerManager.playergold -= price; 
        
    }

    public void IncreasePrice(){
        price += increasePrice;
        increasePrice += 50;
    }
}
