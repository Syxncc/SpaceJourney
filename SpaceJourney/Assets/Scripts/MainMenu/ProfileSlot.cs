using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileSlot : MonoBehaviour
{
    public int slotID;
    public bool thisFull; 
    public GameObject empty; 
    public GameObject full;
    public GameObject xbtn;
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
            xbtn.SetActive(true);
            empty.SetActive(false);
        }
        else {
            full.SetActive(false);
            xbtn.SetActive(false);
            empty.SetActive(true);

        }
    }

    
}
