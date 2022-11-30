using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetRequirement : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject planet;

    public GameObject requirements;

    
    public void OnTriggerEnter(Collider other) {
        Debug.Log("may nangyare");
        requirements.SetActive(true);
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
