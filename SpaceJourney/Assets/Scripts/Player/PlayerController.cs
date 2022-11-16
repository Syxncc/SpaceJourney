using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //private bool movingDir = false; 

    private Transform child;

    [SerializeField]
    private GameObject interactbtn;

    [SerializeField]
    public float playerSpeed = 10.0f;

    [SerializeField]
    public float jumpHeight = 0.5f;

    [SerializeField]
    private float gravityValue = 9.81f;

    [SerializeField]
    private float rotationSpeed = 0.1f;

    private bool interactive;

    [SerializeField]
    private float forceMagnitude;

    

    // [SerializeField]
    // private Transform interactablePoint;
    
    // [SerializeField]
    // private float interactablePointRadius = 0.3f;

    // [SerializeField]
    // private LayerMask interactableMask;

    // [SerializeField]
    // private int objectToInteract;

    // private readonly Collider[] interactCollider = new Collider[1];
        

    private void Awake() {
        playerInput = new Player();
        //controller = GetComponent<CharacterController>();
        
    }

    private void OnEnable(){
        playerInput.Enable();
    }

    private void OnDisable(){
        playerInput.Disable();
    }
    
    private void Start()
    {
        child = transform.GetChild(0).transform;
        animator = GetComponentInChildren<Animator>();
        
        interactbtn.SetActive(false);
        interactive = false;
        
    }

    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
 
        //get joystick input
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        

        //move to the direction base on the camera's facing
        Vector3 move = (cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x);
        //avoid moving on y axis 
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);
        //Move();

        if (move != Vector3.zero)
        {
            //movingDir = true;
            gameObject.transform.forward = move;
            if (playerInput.PlayerMain.Jump.triggered){
                
                animator.SetBool("isMoving", false);
                animator.SetBool("isJumping", true);
                
            }
            else{
                animator.SetBool("isJumping", false);
                animator.SetBool("isMoving", true);
            }

            
            
            
            Quaternion rotation = Quaternion.Euler(new Vector3(child.localEulerAngles.x, cameraMain.localEulerAngles.y, child.localEulerAngles.z));
            child.rotation = Quaternion.Lerp(child.rotation, rotation, Time.deltaTime * rotationSpeed);
            
        }
        else if (move == Vector3.zero){
            //movingDir = false;
            animator.SetBool("isMoving", false);
            
        }

        //JUMP
        if (groundedPlayer){
            lastGroundedTime = Time.time;
        }
        if (playerInput.PlayerMain.Jump.triggered){
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {
            animator.SetBool("isJumping", false);

            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod){

                playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
                
                animator.SetBool("isJumping", true);
 
                jumpButtonPressedTime = null;
                lastGroundedTime = null; 

            }

            
            
        }




        // Changes the height position of the player..
        // if (groundedPlayer)
        // {
        //     animator.SetBool("isJumping", false);
        //     if (playerInput.PlayerMain.Jump.triggered){
        //         playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        //         animator.SetBool("isJumping", true);
        //     }
            
        // }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // if (movementInput != Vector2.zero){
        //     Quaternion rotation = Quaternion.Euler(new Vector3(child.localEulerAngles.x, cameraMain.localEulerAngles.y, child.localEulerAngles.z));
        //     child.rotation = Quaternion.Lerp(child.rotation, rotation, Time.deltaTime * rotationSpeed);
        // }

        if (interactive == true){
            interactbtn.SetActive(true);
        }
        else {
            interactbtn.SetActive(false);
        }

        

        //detect if there is an npc nearby
        // objectToInteract = Physics.OverlapSphereNonAlloc(interactablePoint.position, 
        //     interactablePointRadius, interactCollider, interactableMask);

        // if (objectToInteract > 0){
        //     interactbtn.SetActive(true);
        // }
        // else{
        //     interactbtn.SetActive(false);
        // }
    }

    public void OnTriggerEnter(Collider other){
        if (other.tag == "NPC"){
            interactive = true;
        }
    }

    public void OnTriggerExit(Collider other){
        if (other.tag == "NPC"){
            
            interactive = false;
        }
    }

    public void CheckTalk(string targetNPCTalk, string npcName){
        if (targetNPCTalk == npcName){
            quest.Complete();
        }
    }

    // public void Jump(){
    //     if (groundedPlayer)
    //     {
            
    //         playerVelocity.y += Mathf.Sqrt(jumpHeight * -.0f * gravityValue);
    //         animator.SetBool("isJumping", true);
            
            
    //     }
        
    //     playerVelocity.y += gravityValue * Time.deltaTime;
    //     controller.Move(playerVelocity * Time.deltaTime);

    //     animator.SetBool("isJumping", false);
    // }
    private void OnControllerColliderHit(ControllerColliderHit hit){
        
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody !=null){
            if (hit.collider.tag == "ObjectPush"){
                
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.Normalize();

                rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            }
            
        }    
    }
}
