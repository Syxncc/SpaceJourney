using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Trading : MonoBehaviour
{
    public string gemType;
    private int quantity;
    private int tradingPrice;
    public int initialPrice;
    private int maxQuantity;
    private bool isMax = false;
    private bool isMin = true;

    public Text quantityText;
    public Text tradingText;

    public Button maxbtn;
    public Button minbtn;
    public Button exchangebtn;
    private PlayerManager playerManager;

    void Start()
    {
        playerManager = GameManager.instance.playerManager;
    }


    // Update is called once per frame
    void Update()
    {

        quantityText.text = quantity.ToString();
        displayPrice();

        if (gemType == "Blue")
        {
            maxQuantity = playerManager.playerProfile.playerbluegem;
        }
        else if (gemType == "Green")
        {
            maxQuantity = playerManager.playerProfile.playergreengem;
        }
        else if (gemType == "Red")
        {
            maxQuantity = playerManager.playerProfile.playerredgem;
        }

        if (quantity == maxQuantity)
        {
            isMax = true;
        }
        else
        {
            isMax = false;
        }

        if (quantity == 0)
        {
            isMin = true;
        }
        else
        {
            isMin = false;
        }

        if (isMax)
        {
            maxbtn.interactable = false;
        }
        else
        {
            maxbtn.interactable = true;
        }

        if (isMin)
        {
            minbtn.interactable = false;
        }
        else
        {
            minbtn.interactable = true;
        }

        if (tradingPrice == 0)
        {
            exchangebtn.interactable = false;
        }
        else
        {
            exchangebtn.interactable = true;
        }
    }

    public void increaseQuantity()
    {
        if (!isMax)
        {
            quantity++;
        }

    }

    public void decreaseQuantity()
    {
        if (!isMin)
        {
            quantity--;
        }
    }

    public void displayPrice()
    {
        if (quantity != 0)
        {
            tradingPrice = initialPrice * quantity;
        }
        else
        {
            tradingPrice = 0;
        }
        tradingText.text = tradingPrice.ToString();
    }

    public void Exchange()
    {
        GameManager.instance.shopManager.deductGem(gemType, quantity);
        GameManager.instance.shopManager.tradeToGold(tradingPrice);
        tradingPrice = 0;
        quantity = 0;
    }

}
