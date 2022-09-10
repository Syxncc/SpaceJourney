using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipConttrol : MonoBehaviour
{

    private Player shipInput;

    public float forwardSpeed = 300f;
    public float activeForwardSpeed;
    public float forwardAcceleration = 250f;
    public float thrust;
    public float lookRateSpeed = 30f;

    public Transform bulletSpawnPoint1;
    public Transform bulletSpawnPoint2;
    public GameObject bulletPrefab;
    public float bulletSpeed = 900;



    public bool moveButton;
    public bool shootButton;

    private void Awake() {
        shipInput = new Player();
    }

    private void OnEnable(){
        shipInput.Enable();
    }

    private void OnDisable(){
        shipInput.Disable();
    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = shipInput.ShipMain.Move.ReadValue<Vector2>();

        if (moveButton){
            thrust = 1f;
        }
        else {
            thrust = 0f;
        }

        

        transform.Rotate(-movementInput.y * lookRateSpeed * Time.deltaTime, 
            movementInput.x * lookRateSpeed * Time.deltaTime, 0f, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, thrust * forwardSpeed, forwardAcceleration * Time.deltaTime);
        
        transform.position += transform.forward* activeForwardSpeed* Time.deltaTime; 

        if (shootButton){//shipInput.ShipMain.Shoot.triggered
            var bullet1 = Instantiate(bulletPrefab, bulletSpawnPoint1.position, bulletSpawnPoint1.rotation);
            bullet1.GetComponent<Rigidbody>().velocity= bulletSpawnPoint1.forward * bulletSpeed;
            var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoint2.position, bulletSpawnPoint2.rotation);
            bullet2.GetComponent<Rigidbody>().velocity= bulletSpawnPoint2.forward * bulletSpeed;
        }
        
    }

    public void HoldJoystick(){
        moveButton = true;
    }

    public void ReleaseJoystick(){
        moveButton = false;
    }

    public void HoldShoot(){
        shootButton = true;
    }

    public void ReleaseShoot(){
        shootButton = false;
    }

}
