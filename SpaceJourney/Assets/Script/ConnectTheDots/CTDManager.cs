using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTDManager : MonoBehaviour
{
    public static CTDManager instance;
    public int currentIndex = 0;
    public GameObject[] constellations;
    public GameObject[] constellationInfo;

    public GameObject congrats;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        currentIndex = 0;
        DisconnetTheDots();
        SetActiveNext();
    }

    public void Verify()
    {
        // if (currentIndex < constellations.Length)
        // {
        //     if (IsCorrect())
        //     {
        //         foreach (Transform child in transform)
        //         {
        //             GameObject.Destroy(child.gameObject);
        //         }

        //         if (currentIndex < constellations.Length)
        //         {
        //             constellations[currentIndex].SetActive(false);
        //             Collectible collectible = constellations[currentIndex].GetComponent<ConnectTheDotsProfile>().constellation;
        //             collectible.isUnlockCollectible = true;
        //             constellationInfo[currentIndex].SetActive(true);
        //             currentIndex++;
        //             constellations[currentIndex].SetActive(true);
        //         }
        //         else
        //         {
        //             congrats.SetActive(true);
        //             DisconnetTheDots();
        //         }
        //     }
        // }
        // else
        // {
        //     congrats.SetActive(true);
        //     DisconnetTheDots();
        // }

        if (IsCorrect())
        {
            if (!SetActiveNext())
            {
                congrats.SetActive(true);
            }
            else
            {
                ConnectTheDotsProfile currentProfile = constellations[currentIndex].GetComponent<ConnectTheDotsProfile>();
                currentProfile.constellation.isUnlockCollectible = true;
                currentProfile.SetContentActive(true);
                SetActiveNext();
            }
            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            DisconnetTheDots();
        }
    }

    bool SetActiveNext()
    {
        for (int i = 0; i < constellations.Length; i++)
        {
            ConnectTheDotsProfile profile = constellations[i].GetComponent<ConnectTheDotsProfile>();
            if (!profile.constellation.isUnlockCollectible)
            {
                constellations[i].gameObject.SetActive(true);
                currentIndex = i;
                return true;
            }
        }
        congrats.SetActive(true);
        return false;
    }

    private bool IsCorrect()
    {
        ConstellationDotProfile[] dots = constellations[currentIndex].GetComponent<ConnectTheDotsProfile>().GetAllConstellationDot();
        foreach (ConstellationDotProfile dotProfile in dots)
        {
            for (int i = 0; i < dotProfile.connectedDots.Length; i++)
            {
                if (!dotProfile.connectedDots[i].isConnected)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void DisconnetTheDots()
    {
        for (int i = 0; i < constellations.Length; i++)
        {
            ConstellationDotProfile[] dots = constellations[i].GetComponent<ConnectTheDotsProfile>().GetAllConstellationDot();
            foreach (ConstellationDotProfile dotProfile in dots)
            {
                for (int j = 0; j < dotProfile.connectedDots.Length; j++)
                {
                    if (dotProfile.connectedDots[j].isConnected)
                    {
                        dotProfile.connectedDots[j].isConnected = false;
                    }
                }
            }
        }
        print("Cleared Connected Dots");
    }
}
