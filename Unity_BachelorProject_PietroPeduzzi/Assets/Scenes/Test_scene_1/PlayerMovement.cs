using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    //animations
    private Animator animator;
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

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();

        //animations
        animator = GetComponentInChildren<Animator>();
        velocityHash = Animator.StringToHash("Velocity");
    }

    void Update()
    {
        //JumpBehaviour();

        //animations
        animVelocity = rb.velocity.magnitude;
        animator.SetFloat(velocityHash, animVelocity);
    }

    private void FixedUpdate()
    {
        SideMovement();
    }

    private void SideMovement()
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        //move player
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3(MoveVector.x, rb.velocity.y, MoveVector.z);

        //player look direction
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            gameObject.transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
        }
    }

    private void JumpBehaviour()
    {
        bool jumpKeyPressed = Input.GetKeyDown(KeyCode.W);

        if (jumpKeyPressed && isGrounded())
        {
            Vector3 jumpVector = Vector3.up * jumpForce;
            jumpVector.x = rb.velocity.x;
            jumpVector.z = rb.velocity.z;
            rb.velocity = jumpVector;
        }
    }
    private bool isGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position, -gameObject.transform.up, playerCollider.bounds.extents.y + 0.1f);
        return isGrounded;
    }
}
