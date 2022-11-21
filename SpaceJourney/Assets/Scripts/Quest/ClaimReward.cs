using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClaimReward : MonoBehaviour
{
    public Quest quest;
    
    public GameObject questTexts;
    public Text currentGoldText;
    public int currentGold;
    public Text currentGemText;
    private int currentGem;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentGoldText.text = GameManager.instance.playerManager.gold.ToString();
        currentGemText.text = GameManager.instance.playerManager.gem.ToString();
    }

    public void Claimed(){
        currentGold = currentGold + quest.goldReward;
        
    }

    public void ClearQuest(){
        questTexts.SetActive(false);

    }

    
}
