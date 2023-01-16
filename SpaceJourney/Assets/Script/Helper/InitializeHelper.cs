using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
