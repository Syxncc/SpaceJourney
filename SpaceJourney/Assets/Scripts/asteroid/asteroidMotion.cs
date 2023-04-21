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

    public bool willDestroy = false;
    public TrailRenderer trail;
    


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

    
    void OnTriggerEnter(Collider other)
    {
        
        
        if (willDestroy)
        {
            if (other.gameObject.tag == "Planets" || other.gameObject.tag == "Player" )
            {
                
                GameManager.instance.ChangeMessagePopupPanel(true, null, true);
                Destroy(gameObject);
                
            }
        }
        
    }
}
