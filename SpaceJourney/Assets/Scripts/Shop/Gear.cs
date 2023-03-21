using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gear : MonoBehaviour
{

    public string gearName;
    public GameObject[] levelBar;

    public Text pricetxt;
    public int price;

    private int level;
    private int countBar;
    private int increasePrice = 50;
    int tempLevel = 1;

    private Profile playerProfile;

    void Start()
    {
        countBar = 0;
        level = 0;
        playerProfile = GameManager.instance.playerManager.playerProfile;
        InstantiateLevelUpgrade();
    }

    // Update is called once per frame
    void Update()
    {
        // pricetxt.text = "Price: " + price.ToString();
    }

    public void Upgrade()
    {
        GameManager.instance.SaveCurrentCharacterPosition();
        Debug.Log(tempLevel);
        level = tempLevel;
        //check if the level is maxed
        if (level > 5)
        {
            Debug.Log("Max Level");
            GetComponent<Button>().interactable = false;
            //promptMaxed.SetActive(true);
        }
        else
        {
            //check if sufficient balance
            if (price > playerProfile.playergold)
            {
                Debug.Log("Inssuficient Gold");
                //promptNoCoin.SetActive(true);
            }
            else
            {
                enableBar();
                //GameManager.instance.shopManager.DeductPrice(price);
                // IncreasePrice();
            }
        }
    }

    public void enableBar()
    {
        level++;
        // levelBar[countBar].SetActive(true);
        countBar++;
        playerProfile.playergold -= price;
        InstantiateLevelUpgrade();
        // increaseLevel(level);
    }

    // public void IncreasePrice()
    // {
    //     price = increasePrice * (tempLevel == 0 ? 1 : tempLevel);
    //     // increasePrice += 50;
    // }

    private void InstantiateLevelUpgrade()
    {
        if (gearName == "Walk")
        {
            tempLevel = playerProfile.upgrade.walk;
        }
        else if (gearName == "Sprint")
        {
            tempLevel = playerProfile.upgrade.sprint;
        }
        else if (gearName == "Jump")
        {
            tempLevel = playerProfile.upgrade.jump;
        }
        else if (gearName == "Jump Stamina")
        {
            tempLevel = playerProfile.upgrade.jumpStamina;
        }
        else if (gearName == "Sprint Stamina")
        {
            tempLevel = playerProfile.upgrade.sprintStamina;
        }
        else if (gearName == "Boost")
        {
            tempLevel = playerProfile.upgrade.boost;
        }
        else if (gearName == "Speed")
        {
            tempLevel = playerProfile.upgrade.spaceshipSpeed;
        }
        else if (gearName == "Bullet Overheating")
        {
            tempLevel = playerProfile.upgrade.bulletOverheating;
        }
        price = tempLevel * increasePrice;
        pricetxt.text = "Price: " + price.ToString();
        for (int i = 1; i <= tempLevel; i++)
        {
            levelBar[i - 1].SetActive(true);
            if (i == 5)
            {
                GetComponent<Button>().interactable = false;
                this.enabled = false;
                break;
            }
        }
    }

    // public void increaseLevel(int level)
    // {
    //     if (gearName == "Walk")
    //     {
    //         ShopManager.walkLevel = level;
    //     }
    //     else if (gearName == "Sprint")
    //     {
    //         ShopManager.sprintLevel = level;
    //     }
    //     else if (gearName == "Jump")
    //     {
    //         ShopManager.jumpLevel = level;
    //     }
    //     else if (gearName == "Jump Stamina")
    //     {
    //         ShopManager.jumpStaminaLevel = level;
    //     }
    //     else if (gearName == "Sprint Stamina")
    //     {
    //         ShopManager.sprintStaminaLevel = level;
    //     }
    //     else if (gearName == "Boost")
    //     {
    //         ShopManager.boostLevel = level;
    //     }
    //     else if (gearName == "Speed")
    //     {
    //         ShopManager.speedLevel = level;
    //     }
    //     else if (gearName == "Bullet Overheating")
    //     {
    //         ShopManager.bulletOverheatingLevel = level;
    //     }
    // }
}
