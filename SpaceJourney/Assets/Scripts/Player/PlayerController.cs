using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    }

    void Update()
    {
        // staminaBar.maxValue = playerManager.playerProfile.maxStamina;


        staminaBar.value = currentStamina;

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        //get joystick input
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        if (movementInput == new Vector2(0, 0))
        {
            movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }


        //move to the direction base on the camera's facing
        move = (cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x);

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
        //avoid moving on y axis 
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);


        if (move != Vector3.zero)
        {

            gameObject.transform.forward = move;
            if (playerInput.PlayerMain.Jump.triggered)
            {

                animator.SetBool("isMoving", false);
                animator.SetBool("isJumping", true);

            }
            else
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isMoving", true);
            }




            Quaternion rotation = Quaternion.Euler(new Vector3(child.localEulerAngles.x, cameraMain.localEulerAngles.y, child.localEulerAngles.z));
            child.rotation = Quaternion.Lerp(child.rotation, rotation, Time.deltaTime * rotationSpeed);

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

            animator.SetBool("isJumping", false);
            animator.SetBool("isJumpSprinting", false);
            animator.SetBool("isJumpMoving", false);


            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                if (currentStamina < playerManager.playerProfile.jumpCost)
                {
                    Debug.LogError("Low Stamina");
                }
                else
                {
                    AudioManager.instance.PlaySFX("Jump");
                    DecreaseStaminaNormal(playerManager.playerProfile.jumpCost);
                    playerVelocity.y += Mathf.Sqrt(playerManager.playerProfile.jumpHeight * -2.0f * gravityValue);

                    if (move != Vector3.zero)
                    {

                        if (isSprinting)
                        {
                            Debug.LogError("isJumpSprinting");
                            animator.SetBool("isJumpSprinting", true);

                        }
                        else
                        {
                            Debug.LogError("isJumpMoving");
                            animator.SetBool("isJumpMoving", true);
                        }

                    }
                    else
                    {
                        Debug.LogError("isJumping");
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC" || other.tag == "UpgradeNPC" || other.tag == "TradeNPC" || other.tag == "LaunchNPC")
        {
            interactive = true;
        }

        if (other.GetComponent<Collider>().tag == "Enemy")
        {
            GameManager.instance.ChangeScene(SceneManager.GetActiveScene().buildIndex);
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
    //     Debug.LogError("Dash");

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
