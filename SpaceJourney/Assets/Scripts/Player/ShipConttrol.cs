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

    private PlayerManager playerManager;



    private void Awake()
    {
        shipInput = new Player();
    }

    private void OnEnable()
    {
        shipInput.Enable();
    }

    private void OnDisable()
    {
        shipInput.Disable();
    }



    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameManager.instance.playerManager;
        boostcurrentStamina = playerManager.playerProfile.maxStamina;
        firecurrentStamina = playerManager.playerProfile.maxStamina;

        boostStaminaBar.maxValue = playerManager.playerProfile.maxStamina;
        boostStaminaBar.value = playerManager.playerProfile.maxStamina;

        fireStaminaBar.maxValue = playerManager.playerProfile.maxStamina;
        fireStaminaBar.value = playerManager.playerProfile.maxStamina;

    }

    // Update is called once per frame
    void Update()
    {
        //Stamina
        boostStaminaBar.maxValue = playerManager.playerProfile.maxStamina;
        fireStaminaBar.maxValue = playerManager.playerProfile.maxStamina;

        if (firecurrentStamina < playerManager.playerProfile.maxStamina)
        {
            RegenFireStamina(GameManager.instance.playerManager.playerProfile.regenCost);
        }
        if (boostcurrentStamina < playerManager.playerProfile.maxStamina)
        {
            RegenBoostStamina(GameManager.instance.playerManager.playerProfile.regenCost);
        }

        boostStaminaBar.value = boostcurrentStamina;
        fireStaminaBar.value = firecurrentStamina;

        Vector2 movementInput = shipInput.ShipMain.Move.ReadValue<Vector2>();

        if (moveButton)
        {
            if (boostButton)
            {

                if (boostcurrentStamina >= 0)
                {
                    DecreaseStaminaBoostOvertime();
                    boostTrail.SetActive(true);
                    normalTrail.SetActive(false);

                    thrust = playerManager.playerProfile.thrustBoosted;
                }
                else
                {
                    thrust = 1f;
                    boostTrail.SetActive(false);
                    normalTrail.SetActive(true);
                }

            }
            else
            {
                thrust = 1f;
                boostTrail.SetActive(false);
                normalTrail.SetActive(true);
            }

        }
        else
        {
            thrust = 0f;
        }

        transform.Rotate(-movementInput.y * lookRateSpeed * Time.deltaTime, movementInput.x * lookRateSpeed * Time.deltaTime, 0f, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, thrust * forwardSpeed, forwardAcceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;


        if (shootButton)
        {//shipInput.ShipMain.Shoot.triggered


            if (firecurrentStamina >= 0)
            {

                DecreaseStaminaFiringOvertime();
                var bullet1 = Instantiate(bulletPrefab, bulletSpawnPoint1.position, bulletSpawnPoint1.rotation);
                bullet1.GetComponent<Rigidbody>().velocity = bulletSpawnPoint1.forward * bulletSpeed;
                var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoint2.position, bulletSpawnPoint2.rotation);
                bullet2.GetComponent<Rigidbody>().velocity = bulletSpawnPoint2.forward * bulletSpeed;

            }
            else
            {
                shootButton = false;
            }



        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            shootButton = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            shootButton = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            boostButton = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            boostButton = false;
        }


    }

    public void HoldJoystick()
    {
        moveButton = true;
    }

    public void ReleaseJoystick()
    {
        moveButton = false;
    }

    public void HoldShoot()
    {
        shootButton = true;
    }

    public void ReleaseShoot()
    {
        shootButton = false;
    }

    public void HoldBoost()
    {
        boostButton = true;
    }

    public void ReleaseBoost()
    {
        boostButton = false;
    }

    private void RegenFireStamina(float regenCost)
    {
        firecurrentStamina += GameManager.instance.playerManager.playerProfile.regenCost * Time.deltaTime;
    }

    private void RegenBoostStamina(float regenCost)
    {
        boostcurrentStamina += GameManager.instance.playerManager.playerProfile.regenCost * Time.deltaTime;
    }

    private void DecreaseStaminaFiringOvertime()
    {

        firecurrentStamina -= playerManager.playerProfile.firingStaminaCost * Time.deltaTime;
    }

    private void DecreaseStaminaBoostOvertime()
    {
        boostcurrentStamina -= playerManager.playerProfile.boostStaminaCost * Time.deltaTime;
    }



}
