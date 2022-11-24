using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    
    public string userName;
    public int gold;
    public int gem;
    public float jumpHeight = 0.7f;
    public float walkingSpeed = 10f;
    public float sprintingSpeed = 20f;
    public float regenCost = 5f;
    public float decreaseCostOvertime = 15f;
    public float jumpCost = 10f;
    public float maxStamina = 100f;

    public Text currentGoldText;
    public Text currentGemText;
    public Text PlayerNameText;

    void Update()
    {
        currentGoldText.text = gold.ToString();
        currentGemText.text = gem.ToString();
        PlayerNameText.text = userName;
    }

    public void SpaceScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void LabScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
