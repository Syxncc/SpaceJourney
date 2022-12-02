using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoCards : MonoBehaviour
{
    public bool unlock = false;
    public string infoName;
    public GameObject lockInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        lockInfo.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (unlock){
            lockInfo.SetActive(false);
            
        }
        else {
            lockInfo.SetActive(true);
            
        }
    }


}
