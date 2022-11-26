using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIButton : MonoBehaviour
{

    public GameObject upgradeUI;
    public GameObject tradeUI;
    public GameObject shopbtnUI;

    public void ShowUpgradeUI(){
        upgradeUI.SetActive(true);
        tradeUI.SetActive(false);
        shopbtnUI.SetActive(true);
    }
    public void ShowTradeUI(){
        upgradeUI.SetActive(false);
        tradeUI.SetActive(true);
        shopbtnUI.SetActive(true);
    }

}
