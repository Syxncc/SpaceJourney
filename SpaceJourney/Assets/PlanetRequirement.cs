using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetRequirement : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject planet;

    public GameObject requirements;
    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public GameObject UI4;

    
    public void OnTriggerEnter(Collider other) {
        Debug.Log("may nangyare");
        requirements.SetActive(true);
        UI1.SetActive(false);
        UI2.SetActive(false);
        UI3.SetActive(false);
        UI4.SetActive(false);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
