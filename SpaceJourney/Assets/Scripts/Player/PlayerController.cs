using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    private Player playerInput;

    private Animator animator;

    public Transform cameraMain;

    public float jumpButtonGracePeriod;

    private float? lastGroundedTime;

    private float? jumpButtonPressedTime;

    public Quest quest;

    public CharacterController controller;

    private Vector3 playerVelocity;

    private bool groundedPlayer;

    private Transform child;

    [SerializeField]
    private GameObject interactbtn;

    [SerializeField]
    public float playerSpeed;

    // [SerializeField]
    // public float jumpHeight = 0.5f; //ups

    [SerializeField]
    private float gravityValue = 9.81f;

    [SerializeField]
    private float rotationSpeed = 0.1f;

    // [SerializeField]
    // private float dashSpeed = 20f;

    // [SerializeField]
    // private float dashTime = 0.25f;

    private bool interactive;

    [SerializeField]
    private float forceMagnitude;

    private Vector3 move;

    public Slider staminaBar;

    // [SerializeField]
    // private float maxStamina = 100f; //ups 


    private float currentStamina;

    // [SerializeField]
    // private float jumpCost = 10f;
    // [SerializeField]
    // private float decreaseCostOvertime = 10f;

    // [SerializeField]
    // private float regenCost = 5.00f;



    private bool isSprinting = false;

    // private float sprintingSpeed = 20f; //ups

    // private float walkingSpeed = 10f;  //ups
    private PlayerManager playerManager;


    protected TouchField touchField;
    protected float InputRotationX;
    protected float InputRotationY;
    public float RotationSpeed = 10;
    protected Vector3 CharacterPivot;
    protected Vector3 LookDirection;
    public Vector3 CameraPivot;
    public float CameraDistance;
    public CinemachineFreeLook cinemachineFreeLook;

    private Vector3 characterForward;
    private Vector3 characterLeft;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public float adjustSpeedByPlanet;

    public Transform body;

    private bool isMoving = false;

    private void Awake()
    {
        playerInput = new Player();
        //controller = GetComponent<CharacterController>();

    }

    private void OnEnable()
    {
        if (playerInput != null)
        {
            playerInput.Enable();
        }
    }

    private void OnDisable()
    {
        if (playerInput != null)
        {
            playerInput.Disable();
        }
    }

    private void Start()
    {
        playerManager = GameManager.instance.playerManager;

        currentStamina = playerManager.playerProfile.maxStamina;
        staminaBar.maxValue = playerManager.playerProfile.maxStamina;
        staminaBar.value = playerManager.playerProfile.maxStamina;


        child = transform.GetChild(0).transform;
        animator = GetComponentInChildren<Animator>();

        interactbtn.SetActive(false);
        interactive = false;
        touchField = FindObjectOfType<TouchField>();
        adjustSpeedByPlanet = AdjustSpeedByPlanet();
        // touchField.UseFixedUpdate = true;
        body.position = new Vector3(body.position.x, body.position.y - 2.6f, body.position.z);
    }

    float AdjustSpeedByPlanet()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        foreach (Planet planet in GameManager.instance.collectibles)
        {
            if (planet.planetScene == currentScene)
            {
                Debug.Log(planet.name);
                return planet.adjustSpeedMultiplier;
            }
        }
        return 1;
    }

    void Update()
    {
        staminaBar.value = currentStamina;
        // staminaBar.maxValue = playerManager.playerProfile.maxStamina;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            animator.SetBool("isJumping", false);
            playerVelocity.y = 0f;
        }

        //get joystick input
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        if (movementInput == new Vector2(0, 0))
        {
            movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        //Touch Input
        // InputRotationX = InputRotationX + touchField.TouchDist.x * RotationSpeed * Time.deltaTime % 360f * Camera.main.transform.eulerAngles.y;
        // InputRotationY = Mathf.Clamp(InputRotationY - touchField.TouchDist.y * RotationSpeed * Time.deltaTime, -88f, 88f);
        // characterForward = Quaternion.AngleAxis(InputRotationX, Vector3.up) * Vector3.forward;
        // characterLeft = Quaternion.AngleAxis(InputRotationX + 90, Vector3.up) * Vector3.forward;
        // var runDirection = characterForward * (Input.GetAxisRaw("Vertical") + movementInput.y) + characterLeft * (Input.GetAxisRaw("Horizontal") + movementInput.x);
        // LookDirection = Quaternion.AngleAxis(InputRotationY, characterLeft) * characterForward;

        //move to the direction base on the camera's facing
        // move = (cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x);
        // move = runDirection;

        //Sprinting
        if (isSprinting && currentStamina > 0)
        {
            playerSpeed = playerManager.playerProfile.sprintingSpeed;
            StaminaOvertime(false);
        }
        else
        {
            playerSpeed = playerManager.playerProfile.walkingSpeed;
            if ((move == Vector3.zero || !isSprinting) && currentStamina < 100)
            {
                StaminaOvertime(true);
            }
        }
        Vector3 direction = new Vector3(movementInput.x, 0f, movementInput.y).normalized;

        //avoid moving on y axis 
        // move.y = 0f;
        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            move = moveDir;
            controller.Move(move * Time.deltaTime * playerSpeed * adjustSpeedByPlanet);
            animator.SetBool("isMoving", true);
            if (!isMoving)
            {
                isMoving = true;
                AudioManager.instance.PlayLoopSFX("Sprint");
            }
        }
        else
        {
            if (isMoving)
            {
                isMoving = false;
                AudioManager.instance.StopSFXLoop("Sprint");
            }
            animator.SetBool("isMoving", false);
        }
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            if (playerInput.PlayerMain.Jump.triggered)
            {
                animator.SetBool("isJumping", true);

            }
            else
            {
                animator.SetBool("isJumping", false);

            }



            // Quaternion rotation = Quaternion.Euler(new Vector3(child.localEulerAngles.x, cameraMain.localEulerAngles.y, child.localEulerAngles.z));
            // child.rotation = Quaternion.Lerp(child.rotation, rotation, Time.deltaTime * rotationSpeed);

        }
        else if (move == Vector3.zero)
        {
            //movingDir = false;
            animator.SetBool("isMoving", false);

        }

        //JUMP

        if (groundedPlayer)
        {
            lastGroundedTime = Time.time;
        }
        if (playerInput.PlayerMain.Jump.triggered)
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {

            // animator.SetBool("isJumping", false);
            // animator.SetBool("isJumpSprinting", false);
            // animator.SetBool("isJumpMoving", false);


            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                if (currentStamina < playerManager.playerProfile.jumpCost)
                {
                    Debug.Log("Low Stamina");
                }
                else
                {
                    AudioManager.instance.PlaySFX("Jump");
                    DecreaseStaminaNormal(playerManager.playerProfile.jumpCost);
                    playerVelocity.y += Mathf.Sqrt(playerManager.playerProfile.jumpHeight * adjustSpeedByPlanet * -2.0f * gravityValue);

                    if (move != Vector3.zero)
                    {

                        if (isSprinting)
                        {
                            Debug.Log("isJumpSprinting");
                            animator.SetBool("isJumpSprinting", true);

                        }
                        else
                        {
                            animator.SetBool("isJumping", true);
                        }

                    }
                    else
                    {
                        Debug.Log("isJumping");
                        animator.SetBool("isJumping", true);
                    }

                    jumpButtonPressedTime = null;
                    lastGroundedTime = null;
                }

            }

        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // if (move != Vector3.zero && isSprinting)
        // {

        //     StaminaOvertime(-1);
        // }


        if (interactive == true)
        {
            interactbtn.SetActive(true);
        }
        else
        {
            interactbtn.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        // Camera.main.transform.position = (transform.position + CharacterPivot) - LookDirection * CameraDistance;
        // Camera.main.transform.rotation = Quaternion.LookRotation(LookDirection, Vector3.up);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC" || other.tag == "UpgradeNPC" || other.tag == "TradeNPC" || other.tag == "LaunchNPC")
        {
            interactive = true;
        }

        if (other.GetComponent<Collider>().tag == "Enemy")
        {
            if (GameManager.instance.countdownTimer == null)
            {
                GameManager.instance.ChangeScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                gameObject.SetActive(false);
                GameManager.instance.ChangeMessagePopupPanel(true, null, true);
            }
        }

    }

    // public void OnTriggerEnter(Collider other)
    // {
    //     if (other.collider.tag == "Enemy")
    //     {
    //         GameManager.instance.ChangeScene(SceneManager.GetActiveScene().buildIndex);
    //     }
    // }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC" || other.tag == "UpgradeNPC" || other.tag == "TradeNPC" || other.tag == "LaunchNPC")
        {
            interactive = false;
        }
    }

    // public void CheckTalk(string targetNPCTalk, string npcName){
    //     if (targetNPCTalk == npcName){
    //         quest.Complete();
    //     }
    // }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null)
        {
            if (hit.collider.tag == "ObjectPush")
            {

                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();

                rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            }

        }
    }

    // public void DashPlayer(){
    //     DecreaseStamina(dashCost);
    //     StartCoroutine(Dash());


    // }

    // IEnumerator Dash(){
    //     float startTime = Time.time;
    //     Debug.Log("Dash");

    //     while(Time.time < startTime + dashTime){
    //         controller.Move(move * dashSpeed * Time.deltaTime);
    //         yield return null;
    //     }
    // }

    private void StaminaOvertime(bool isIncreasing)
    {
        if (isIncreasing && playerManager.playerProfile.maxStamina > currentStamina)
        {
            currentStamina += playerManager.playerProfile.regenCost * Time.deltaTime;
        }
        else
        {
            currentStamina -= playerManager.playerProfile.decreaseCostOvertime * Time.deltaTime;
        }
    }

    // private void DecreaseStaminaOvertime()
    // {

    //     currentStamina -= playerManager.playerProfile.decreaseCostOvertime * Time.deltaTime;

    // }

    private void DecreaseStaminaNormal(float decreaseCost)
    {
        currentStamina -= decreaseCost;

    }

    public void Sprint(bool sprint)
    {
        this.isSprinting = sprint;
    }
}
