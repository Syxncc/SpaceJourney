using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public PlayerManager playerManager;
    private Vector2 movementInput;
    public int playerMove = 1;

    public GameObject planet;
    Profile playerProfile;


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
        playerProfile = playerManager.playerProfile;
        boostcurrentStamina = playerProfile.maxStamina;
        firecurrentStamina = playerProfile.maxStamina;

        boostStaminaBar.maxValue = playerProfile.maxStamina;
        boostStaminaBar.value = playerProfile.maxStamina;

        fireStaminaBar.maxValue = playerProfile.maxStamina;
        fireStaminaBar.value = playerProfile.maxStamina;
        normalTrail.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        //Stamina
        // boostStaminaBar.maxValue = playerProfile.maxStamina;
        // fireStaminaBar.maxValue = playerProfile.maxStamina;
        // Debug.Log(playerProfile.maxStamina);
        if (firecurrentStamina < playerProfile.maxStamina)
        {
            RegenFireStamina(playerProfile.regenCost);
        }
        if (boostcurrentStamina < playerProfile.maxStamina)
        {
            RegenBoostStamina(playerProfile.regenCost);
        }

        boostStaminaBar.value = boostcurrentStamina;
        fireStaminaBar.value = firecurrentStamina;

        movementInput = shipInput.ShipMain.Move.ReadValue<Vector2>();

        // if (!moveButton)
        // {
        //     thrust = 0f;
        // }
        transform.Rotate(-movementInput.y * lookRateSpeed * Time.deltaTime, movementInput.x * lookRateSpeed * Time.deltaTime, 0f, Space.Self);

        if (boostButton || moveButton)
        {
            if (boostButton && boostcurrentStamina >= 0)
            {
                DecreaseStaminaBoostOvertime();

                thrust = playerProfile.thrustBoosted;
            }
            else
            {
                thrust = 1f;
            }
            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, (thrust + (playerProfile.upgrade.spaceshipSpeed * .2f)) * forwardSpeed, forwardAcceleration * Time.deltaTime);
            transform.position += transform.forward * activeForwardSpeed * Time.deltaTime * playerMove;
        }
        else
        {
            thrust = 0;
        }

        if (shootButton)
        {//shipInput.ShipMain.Shoot.triggered

            AudioManager.instance.PlaySFX("Bullet");

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


        if (Input.GetKeyDown(KeyCode.F))
        {
            shootButton = true;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            shootButton = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            boostButton = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            boostButton = false;
        }


    }

    public Vector2 GetPlayerMovement()
    {
        return movementInput;
    }

    // public void HoldJoystick()
    // {
    //     moveButton = true;
    // }

    // public void ReleaseJoystick()
    // {
    //     moveButton = false;
    // }

    public void HoldShoot()
    {
        GameManager.instance.SaveCurrentCharacterPosition();
        shootButton = true;
    }

    public void MoveFire(bool isFiring)
    {
        shootButton = isFiring;
        MoveNormal(isFiring);
    }

    public void MoveNormal(bool isMoving)
    {
        moveButton = isMoving;
    }

    public void ReleaseShoot()
    {
        shootButton = false;
    }

    public void isBoost(bool isBoost)
    {
        boostButton = isBoost;
    }

    private void RegenFireStamina(float regenCost)
    {
        firecurrentStamina += playerProfile.regenCost * Time.deltaTime;
    }

    private void RegenBoostStamina(float regenCost)
    {
        boostcurrentStamina += playerProfile.regenCost * Time.deltaTime;
    }

    private void DecreaseStaminaFiringOvertime()
    {

        firecurrentStamina -= (playerProfile.firingStaminaCost - (playerProfile.upgrade.bulletOverheating * 2)) * Time.deltaTime;
    }

    private void DecreaseStaminaBoostOvertime()
    {
        boostcurrentStamina -= (playerProfile.boostStaminaCost - (playerProfile.upgrade.boost * 1f)) * Time.deltaTime;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (GameManager.instance.countdownTimer == null)
            {
                GameManager.instance.ChangeScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                gameObject.SetActive(false);
                if (other.GetComponent<Lifebar>() != null)
                {
                    other.GetComponent<Lifebar>().slider.gameObject.SetActive(false);
                }
                GameManager.instance.ChangeMessagePopupPanel(true, null, true);
            }
        }

        if (other.gameObject.tag == "Planets")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
