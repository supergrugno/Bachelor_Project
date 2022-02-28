using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private LayerMask pickUPLayer;
    [SerializeField] private LayerMask slotLayer;
    [SerializeField] private GameObject rayCasterObj;
    [SerializeField] private float pickUpRange;
    [SerializeField] private float throwingForce;
    [SerializeField] private Transform Hand;

    private int rayCastModifier = 1;

    private Rigidbody CurrentObjectRigidBody;
    private Collider CurrentObjectCollider;

    private Rigidbody floatingRigidBody = null;
    private Collider floatingCollider = null;


    //animations
    private Animator animator;
    private bool hasObjectInHand;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        CheckDirection();
        GetObject();
    }

    private void CheckDirection()
    {
        if (StaticValues.isLookingRight == true) rayCastModifier = 1;
        else if (StaticValues.isLookingRight == false) rayCastModifier = -1;
    }

    private void GetObject()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Ray Pickupray = new Ray(rayCasterObj.transform.position, rayCastModifier * rayCasterObj.transform.right);

            if (Physics.Raycast(Pickupray, out RaycastHit hitInfo_1, pickUpRange, pickUPLayer))
            {
                if (CurrentObjectRigidBody)
                {
                    //SWITCH object
                    CurrentObjectRigidBody.isKinematic = false;
                    CurrentObjectCollider.enabled = true;

                    CurrentObjectRigidBody = hitInfo_1.rigidbody;
                    CurrentObjectCollider = hitInfo_1.collider;

                    CurrentObjectRigidBody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;

                    //animation
                    animator.SetBool("Has Object", true);
                    hasObjectInHand = true;
                }
                else
                {
                    //PICKUP object
                    CurrentObjectRigidBody = hitInfo_1.rigidbody;
                    CurrentObjectCollider = hitInfo_1.collider;

                    CurrentObjectRigidBody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;


                    //animation
                    animator.SetBool("Has Object", true);
                    hasObjectInHand = true;
                }

                return;

            }else if(Physics.Raycast(Pickupray, out RaycastHit hitInfo_2, pickUpRange, slotLayer))
            {
                SlotManager slotReference = hitInfo_2.transform.GetComponent<SlotManager>();
                //crafting
                if (CurrentObjectRigidBody && slotReference.slotIsFull == false)
                {
                    //Debug.Log("added item to crafer");
                    slotReference.slotIsFull = true;

                    slotReference.slotObjectRigidBody = CurrentObjectRigidBody;
                    slotReference.slotObjectCollider = CurrentObjectCollider;

                    slotReference.slotObjectRigidBody.isKinematic = true;
                    slotReference.slotObjectCollider.enabled = false;

                    CurrentObjectRigidBody = null;
                    CurrentObjectCollider = null;

                    //animation
                    animator.SetBool("Has Object", false);
                    hasObjectInHand = false;
                }
                else if(!CurrentObjectRigidBody && slotReference.slotIsFull == true)
                {
                    //Debug.Log("took item from crafer");

                    CurrentObjectRigidBody = slotReference.slotObjectRigidBody;
                    CurrentObjectCollider = slotReference.slotObjectCollider;

                    CurrentObjectRigidBody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;

                    slotReference.slotObjectRigidBody = null;
                    slotReference.slotObjectCollider = null;

                    //animation
                    animator.SetBool("Has Object", true);
                    hasObjectInHand = true;

                    slotReference.slotIsFull = false;
                }
                else if (CurrentObjectRigidBody && slotReference.slotIsFull == true)
                {
                    //Debug.Log("switched item in crafer");

                    floatingRigidBody = CurrentObjectRigidBody;
                    floatingCollider = CurrentObjectCollider;

                    CurrentObjectRigidBody = slotReference.slotObjectRigidBody;
                    CurrentObjectCollider = slotReference.slotObjectCollider;

                    CurrentObjectRigidBody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;

                    slotReference.slotObjectRigidBody = floatingRigidBody;
                    slotReference.slotObjectCollider = floatingCollider;

                    slotReference.slotObjectRigidBody.isKinematic = true;
                    slotReference.slotObjectCollider.enabled = false;

                    floatingRigidBody = null;
                    floatingCollider = null;

                    //animation
                    animator.SetBool("Has Object", true);
                    hasObjectInHand = true;
                }

                 return;
            }
            

            // DROP object
            if (CurrentObjectRigidBody)
            {
                CurrentObjectRigidBody.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                //animation
                animator.SetBool("Has Object", false);
                hasObjectInHand = false;

                CurrentObjectRigidBody = null;
                CurrentObjectCollider = null;
            }
        }

        if (Input.GetButtonDown("Action"))
        {
            //THROW object
            if (CurrentObjectRigidBody)
            {
                CurrentObjectRigidBody.isKinematic = false;
                CurrentObjectCollider.enabled = true;

                if (StaticValues.isLookingRight == true) CurrentObjectRigidBody.AddForce((Hand.right + Hand.up) * throwingForce, ForceMode.Impulse);
                else if (StaticValues.isLookingRight == false) CurrentObjectRigidBody.AddForce((-Hand.right + Hand.up) * throwingForce, ForceMode.Impulse);


                //animation
                animator.SetBool("Has Object", false);
                hasObjectInHand = false;

                CurrentObjectRigidBody = null;
                CurrentObjectCollider = null;
            }
        }

        if (CurrentObjectRigidBody)
        {
            CurrentObjectRigidBody.position = Hand.position;
            CurrentObjectRigidBody.rotation = Hand.rotation;
        }
    }
}
