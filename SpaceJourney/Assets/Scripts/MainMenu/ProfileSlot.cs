using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileSlot : MonoBehaviour
{
    public bool thisFull; 
    public GameObject empty; 
    public GameObject full;
    // Start is called before the first frame update
    void Start()
    {
        thisFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (thisFull){
            full.SetActive(true);
        }
        else {
            full.SetActive(false);
        }
    }

    
}
