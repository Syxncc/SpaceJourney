using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private bool moveButton;
    private bool shootButton;
    private bool boostButton;

    public Slider boostStaminaBar;
    public Slider fireStaminaBar;
    private float boostcurrentStamina;
    private float firecurrentStamina;

    public GameObject boostTrail;
    public GameObject normalTrail;


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
        boostcurrentStamina = PlayerManager.maxStamina;
        firecurrentStamina = PlayerManager.maxStamina;

        boostStaminaBar.maxValue = PlayerManager.maxStamina;
        boostStaminaBar.value = PlayerManager.maxStamina;

        fireStaminaBar.maxValue = PlayerManager.maxStamina;
        fireStaminaBar.value = PlayerManager.maxStamina;

    }

    // Update is called once per frame
    void Update()
    {
        //Stamina
        boostStaminaBar.maxValue = PlayerManager.maxStamina;
        fireStaminaBar.maxValue = PlayerManager.maxStamina;

        if (firecurrentStamina < PlayerManager.maxStamina){
            RegenFireStamina(GameManager.instance.playerManager.regenCost);
        }
        if (boostcurrentStamina < PlayerManager.maxStamina){
            RegenBoostStamina(GameManager.instance.playerManager.regenCost);
        }
        
        boostStaminaBar.value = boostcurrentStamina;
        fireStaminaBar.value = firecurrentStamina;
        
        Vector2 movementInput = shipInput.ShipMain.Move.ReadValue<Vector2>();

        if (moveButton){
            if (boostButton){
                
                if (boostcurrentStamina >= 0){
                    DecreaseStaminaBoostOvertime();
                    boostTrail.SetActive(true);
                    normalTrail.SetActive(false);
                    
                    thrust = PlayerManager.thrustBoosted;
                }
                else {
                    thrust = 1f;
                    boostTrail.SetActive(false);
                    normalTrail.SetActive(true);
                }
                
            }
            else {
                thrust = 1f;
                boostTrail.SetActive(false);
                normalTrail.SetActive(true);
            }
            
        }
        else {
            thrust = 0f;
        }

        transform.Rotate(-movementInput.y * lookRateSpeed * Time.deltaTime, movementInput.x * lookRateSpeed * Time.deltaTime, 0f, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, thrust * forwardSpeed, forwardAcceleration * Time.deltaTime);
        
        transform.position += transform.forward* activeForwardSpeed* Time.deltaTime; 
        

        if (shootButton){//shipInput.ShipMain.Shoot.triggered


            if (firecurrentStamina >= 0){
                       
                DecreaseStaminaFiringOvertime();
                var bullet1 = Instantiate(bulletPrefab, bulletSpawnPoint1.position, bulletSpawnPoint1.rotation);
                bullet1.GetComponent<Rigidbody>().velocity= bulletSpawnPoint1.forward * bulletSpeed;
                var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoint2.position, bulletSpawnPoint2.rotation);
                bullet2.GetComponent<Rigidbody>().velocity= bulletSpawnPoint2.forward * bulletSpeed;
                
            }
            else {
                shootButton = false;
            }

            
            
        }

        

        if (Input.GetKeyDown(KeyCode.Space)){
            shootButton = true;
        }

        if (Input.GetKeyUp(KeyCode.Space)){
            shootButton = false;
        } 

        if (Input.GetKeyDown(KeyCode.UpArrow)){
            boostButton = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)){
            boostButton = false;
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

    public void HoldBoost(){
        boostButton = true;
    }

    public void ReleaseBoost(){
        boostButton = false;
    }

    private void RegenFireStamina(float regenCost){
        firecurrentStamina += GameManager.instance.playerManager.regenCost * Time.deltaTime;
    }

    private void RegenBoostStamina(float regenCost){
        boostcurrentStamina += GameManager.instance.playerManager.regenCost * Time.deltaTime;
    }

    private void DecreaseStaminaFiringOvertime(){
        
        firecurrentStamina -= PlayerManager.firingStaminaCost * Time.deltaTime;
    }

    private void DecreaseStaminaBoostOvertime(){
        boostcurrentStamina -= PlayerManager.boostStaminaCost * Time.deltaTime;
    }

}
