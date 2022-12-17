using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCards : MonoBehaviour
{
    public bool unlock = false;
    public string infoName;
    public Collectible planet;
    public GameObject lockInfo;
    public GameObject cardInfo;
    public GameObject backButton;

    // Update is called once per frame
    void Update()
    {
        lockInfo.SetActive(!planet.isUnlockCollectible);
    }

    public void OpenCard()
    {
        cardInfo.SetActive(planet.isUnlockCollectible);
        backButton.SetActive(planet.isUnlockCollectible);
    }
}
