using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    //animations
    public Animator animator;
    private float animVelocity;
    private int velocityHash;
    private bool hasObjectInHand;

    //side movement
    private Vector2 PlayerMovementInput;
    [SerializeField] private float moveSpeed;

    //jump movement
    public LayerMask groundLayers;
    [SerializeField] private float jumpForce;
    private CapsuleCollider playerCollider;

    //others
    public bool _canDig = false;
    public bool _isDigging = false;
    public bool _canPressButton = false;
    public bool _isPressingButton = false;

    [SerializeField] private ParticleSystem dustPS_1;
    [SerializeField] private ParticleSystem dustPS_2;
    private bool isRunning = false;

    //SFX
    [SerializeField] private AudioSource footstepSound;
    [SerializeField] private AudioSource jumpSound;

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
        _isDigging = false;
        _isPressingButton = false;

        //animations
        animator = GetComponentInChildren<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
        StaticValues.isLookingRight = true;

        //SFX
        footstepSound.volume = 0;
    }

    void Update()
    {
        if(!StaticValues.playerIsDead) JumpBehaviour();

        //animations
        animVelocity = rb.velocity.magnitude;
        animator.SetFloat(velocityHash, animVelocity);

        //player look direction + dust
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (isGrounded()) CreateDust(1);
            if (Input.GetAxisRaw("Horizontal") < 0 && StaticValues.isLookingRight)
            {
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                //if(isGrounded()) CreateDust(1);
                StaticValues.isLookingRight = false;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 && !StaticValues.isLookingRight)
            {
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                //if (isGrounded()) CreateDust(1);
                StaticValues.isLookingRight = true;
            }
            if(!isRunning && isGrounded())
            {
                //CreateDust(1);
                isRunning = true;
            }
        }else if (Input.GetAxisRaw("Horizontal") == 0 && isRunning)
        {
            isRunning = false;
        }
    }

    private void FixedUpdate()
    {
        if (!StaticValues.playerIsDead)
        {
            SideMovement();

            if (_canDig) Digging();
            if (_canPressButton) PressingButton();
        }
    }

    private void SideMovement()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        //move player
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3(MoveVector.x, rb.velocity.y, MoveVector.z);

        if (rb.velocity.magnitude >= 0.1f && isGrounded()) footstepSound.volume = 1;
        else footstepSound.volume = 0;
    }

    private void Digging()
    {
        if (Input.GetButton("Action") && rb.velocity.magnitude <= 0.1f)
        {
            animator.SetBool("IsDigging", true);
            _isDigging = true;
        }else
        {
            animator.SetBool("IsDigging", false);
            _isDigging = false;
        }
    }

    private void PressingButton()
    {
        if (Input.GetButton("Action") && rb.velocity.magnitude <= 0.1f)
        {
            animator.SetBool("IsPressingButton", true);
            _isPressingButton = true;
        }
        else
        {
            animator.SetBool("IsPressingButton", false);
            _isPressingButton = false;
        }
    }
    
    private void JumpBehaviour()
    {
        if (isGrounded())
        {
            //animation
            animator.SetBool("IsJumping", false);
        }
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Vector3 jumpVector = Vector3.up * jumpForce;
            jumpVector.x = rb.velocity.x;
            jumpVector.z = rb.velocity.z;
            rb.velocity = jumpVector;

            //animation
            animator.SetBool("IsJumping", true);
            CreateDust(2);
            jumpSound.pitch = Random.Range(0.8f, 1.2f);
            jumpSound.Play();
        }
    }

    private bool isGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position, -gameObject.transform.up, playerCollider.bounds.extents.y + 0.5f, groundLayers);
        return isGrounded;
    }

    private void CreateDust(int PSnumber)
    {
        if (PSnumber == 1) dustPS_1.Play();
        if (PSnumber == 2) dustPS_2.Play();
    }
}
