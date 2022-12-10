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

    // Start is called before the first frame update
    // void Start()
    // {
    //     lockInfo.SetActive(true);
    // }

    // Update is called once per frame
    void Update()
    {
        lockInfo.SetActive(!planet.isUnlock);
        // cardInfo.SetActive(planet.isUnlock);
        // if (planet.isUnlock){
        //     lockInfo.SetActive(false);

        // }
        // else {
        //     lockInfo.SetActive(true);
        //     cardInfo.SetActive(false);
        // }
    }

    public void OpenCard()
    {
        cardInfo.SetActive(planet.isUnlock);
        backButton.SetActive(planet.isUnlock);
    }
}
