using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidMotion : MonoBehaviour
{
    public float minSpinSpeed = 1f;
    public float maxSpinSpeed = 5f;
    public float minThrust = 0.1f;
    public float maxThrust = 0.5f;
    private float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        spinSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
        float thrust = Random.Range(minThrust, maxThrust);
    
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * thrust, ForceMode.Impulse);
    
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

    }
}
