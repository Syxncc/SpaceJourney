using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetStats : MonoBehaviour
{
    public Collectible planetProfile;
    // public string planetName;

    // public GameObject requirements;
    // public Button landButton;
    // public GameObject loadingScene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // public void OnCollisionEnter(Collision other) 
    // {
    //     if (other.gameObject.CompareTag("Player")){
    //        Debug.Log("Wieeee");
    //     }
    // }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Wieeee");
        }
    }




}
