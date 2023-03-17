using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlanetRequirement : MonoBehaviour
{

    public GameObject spaceShip;

    public GameObject requirements;
    public GameObject landButton;
    public GameObject loadingScene;


    private bool requirementPassed;

    private string planetName;

    public TextMeshProUGUI requirementText;
    public TMP_Text requirementTitle;
    private int currentPlanetScene = -1;

    private ShipConttrol shipControl;

    private bool firstEnter = true;

    void Start()
    {
        shipControl = GameManager.instance.playerManager.shipControl;
        requirementPassed = false;
        // landButton.enabled = false;
    }

    void Update()
    {
        // Debug.Log(planetName);
    }

    public void OnTriggerStay(Collider other)
    {
        // if (other.gameObject.CompareTag("Earth"))
        // {
        //     planetName = "Earth";
        //     requirements.SetActive(true);
        //     if (requirementPassed)
        //     {
        //         requirementPassed = false;
        //     }
        // }
        // else if (other.gameObject.CompareTag("Mars"))
        // {
        //     planetName = "Mars";

        // }
        if (other.gameObject.CompareTag("Planets"))
        {
            // if (PlayerMovingForward())
            // {
            //     if (shipControl.playerMove > 0)
            //     {
            //         shipControl.playerMove = 0;
            //     }
            // }
            // else
            // {
            //     if (AreMaxControl(shipControl.GetPlayerMovement().x, .9f) || AreMaxControl(shipControl.GetPlayerMovement().y, .9f))
            //     {
            //         shipControl.playerMove = 1;
            //     }
            // }

            if (firstEnter)
            {
                firstEnter = false;
                if (other.GetComponent<PlanetStats>() != null)
                {
                    Planet collidedPlanet = (Planet)other.GetComponent<PlanetStats>().planetProfile;
                    requirements.SetActive(true);
                    requirementTitle.text = collidedPlanet.name + " Level Requirement";
                    requirementText.text = collidedPlanet.GetPlanetRequirements();
                    Debug.Log(collidedPlanet.isAchieveRequirements());
                    if (collidedPlanet.isAchieveRequirements() || collidedPlanet.name == "Earth")
                    {
                        GameManager.instance.SaveCurrentCharacterPosition();
                        Debug.Log(collidedPlanet.name + " I achieve");
                        currentPlanetScene = collidedPlanet.planetScene;
                        landButton.SetActive(true);
                        if (collidedPlanet.name == "Earth")
                        {
                            requirementText.text = "Welcome Back! Have fun in your travel around the space";
                        }
                    }
                    else
                    {
                        landButton.SetActive(false);
                    }
                }
            }
        }

        // requirement();
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Planets"))
        {
            firstEnter = true;
        }
    }

    private bool AreMaxControl(float direction, float limit)
    {
        return direction > limit && -limit < direction;
    }

    private bool PlayerMovingForward()
    {
        // Debug.Log(shipControl.GetPlayerMovement().x + " " + shipControl.GetPlayerMovement().y);
        return shipControl.GetPlayerMovement().x == 0 && shipControl.GetPlayerMovement().y == 0;
    }

    public void LoadScene()
    {
        GameManager.instance.playerQuest.isTravel = true;
        loadingScene.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(currentPlanetScene);
    }

    // public void landing()
    // {
    //     if (requirementPassed)
    //     {
    //         if (planetName == "Earth")
    //         {
    //             loadingScene.SetActive(true);
    //             AsyncOperation operation = SceneManager.LoadSceneAsync(1);
    //             //SceneManager.LoadScene(1);
    //         }
    //         else if (planetName == "Mars")
    //         {
    //             loadingScene.SetActive(true);
    //             AsyncOperation operation = SceneManager.LoadSceneAsync(3);
    //             //SceneManager.LoadScene(3);
    //         }
    //         else if (planetName == "Mercury")
    //         {
    //             loadingScene.SetActive(true);
    //             AsyncOperation operation = SceneManager.LoadSceneAsync(4);
    //             //SceneManager.LoadScene(4);
    //         }
    //         else if (planetName == "Venus")
    //         {
    //             loadingScene.SetActive(true);
    //             AsyncOperation operation = SceneManager.LoadSceneAsync(5);
    //             //SceneManager.LoadScene(5);
    //         }
    //         else if (planetName == "Asteroid Belt")
    //         {
    //             loadingScene.SetActive(true);
    //             AsyncOperation operation = SceneManager.LoadSceneAsync(6);
    //             //SceneManager.LoadScene(6);
    //         }
    //     }

    // }

    // public void requirement()
    // {
    //     //requirements.SetActive(true);
    //     if (planetName.Equals("Earth"))
    //     {
    //         requirementText.text = "Welcome Back! Have fun in your travel around the space";
    //         requirements.SetActive(true);
    //         requirementPassed = true;
    //         landButton.enabled = true;
    //     }
    //     else if (planetName.Equals("Mars"))
    //     {
    //         if (ShopManager.walkLevel >= 4 && ShopManager.sprintLevel >= 4)
    //         {
    //             requirementText.text = "Requirement Fulfilled";
    //             requirementPassed = true;
    //             landButton.enabled = true;

    //         }
    //         else
    //         {
    //             requirementText.text = "Player Requirement\n\n Walk - lvl.4\n Sprint - lvl.4\n Earth InfoCard";
    //             landButton.enabled = false;
    //         }

    //     }
    //     else if (planetName == "Mercury")
    //     {
    //         if (ShopManager.jumpStaminaLevel >= 4 && ShopManager.sprintLevel >= 4)
    //         {
    //             requirementText.text = "Requirement Fulfilled";
    //             requirementPassed = true;
    //             landButton.enabled = true;

    //         }
    //         else
    //         {
    //             requirementText.text = "Player Requirement\n\n Jump Stamina - lvl.3\n Sprint Stamina - lvl.3\n Walk - lvl.4\n Sprint - lvl.4\n Mars InfoCard";
    //             landButton.enabled = false;
    //         }

    //     }
    //     else if (planetName.Equals("Venus"))
    //     {
    //         if (ShopManager.jumpStaminaLevel >= 4 && ShopManager.sprintStaminaLevel >= 4)
    //         {
    //             requirementText.text = "Requirement Fulfilled";
    //             requirementPassed = true;
    //             landButton.enabled = true;

    //         }
    //         else
    //         {
    //             requirementText.text = "Player Requirement\n\n Jump Stamina - lvl.5\n Sprint Stamina - lvl.5\n Jump - lvl.3\n Mercury InfoCard";
    //             landButton.enabled = false;
    //         }

    //     }
    //     else if (planetName.Equals("Asteroid Belt"))
    //     {
    //         if (ShopManager.speedLevel >= 3 && ShopManager.boostLevel >= 3)
    //         {
    //             requirementText.text = "Requirement Fulfilled";
    //             requirementPassed = true;
    //             landButton.enabled = true;
    //         }
    //         else
    //         {
    //             requirementText.text = "Spaceship Requirement\n\n Speed - lvl.3\n Boost - lvl.3\n Earth InfoCard\nMars InfoCard\nMercury InfoCard\nVenus InfoCard";
    //             landButton.enabled = false;
    //         }
    //     }

    // }

}
