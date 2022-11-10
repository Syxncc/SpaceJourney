using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ClaimReward coinManager;
    public int gearPrice;
    public GameObject noCoins;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeductPrice(){
        if (coinManager.currentGold < gearPrice){
            noCoins.SetActive(true);
        }
        else {
            coinManager.currentGold = coinManager.currentGold - gearPrice;
        }
        
    }

    
}
