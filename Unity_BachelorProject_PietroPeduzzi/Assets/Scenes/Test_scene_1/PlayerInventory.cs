using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private LayerMask pickUPLayer;
    [SerializeField] private GameObject rayCasterObj;
    [SerializeField] private float pickUpRange;
    [SerializeField] private float throwingForce;
    [SerializeField] private Transform Hand;

    private Rigidbody CurrentObjectRigidBody;
    private Collider CurrentObjectCollider;


    //animations
    private Animator animator;
    private bool hasObjectInHand;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        GetObject();
    }

    private void GetObject()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (StaticValues.isLookingRight == true)
            {
                Ray Pickupray = new Ray(rayCasterObj.transform.position, rayCasterObj.transform.right);

                if (Physics.Raycast(Pickupray, out RaycastHit hitInfo, pickUpRange, pickUPLayer))
                {
                    if (CurrentObjectRigidBody)
                    {
                        CurrentObjectRigidBody.isKinematic = false;
                        CurrentObjectCollider.enabled = true;

                        CurrentObjectRigidBody = hitInfo.rigidbody;
                        CurrentObjectCollider = hitInfo.collider;

                        CurrentObjectRigidBody.isKinematic = true;
                        CurrentObjectCollider.enabled = false;


                        //animation
                        animator.SetBool("Has Object", true);
                        hasObjectInHand = true;
                    }
                    else
                    {
                        CurrentObjectRigidBody = hitInfo.rigidbody;
                        CurrentObjectCollider = hitInfo.collider;

                        CurrentObjectRigidBody.isKinematic = true;
                        CurrentObjectCollider.enabled = false;


                        //animation
                        animator.SetBool("Has Object", true);
                        hasObjectInHand = true;
                    }

                    return;
                }
            }
            else if(StaticValues.isLookingRight == false)
            {
                Ray Pickupray = new Ray(rayCasterObj.transform.position, -rayCasterObj.transform.right);
                if (Physics.Raycast(Pickupray, out RaycastHit hitInfo, pickUpRange, pickUPLayer))
                {
                    if (CurrentObjectRigidBody)
                    {
                        //SWITCH object
                        CurrentObjectRigidBody.isKinematic = false;
                        CurrentObjectCollider.enabled = true;

                        CurrentObjectRigidBody = hitInfo.rigidbody;
                        CurrentObjectCollider = hitInfo.collider;

                        CurrentObjectRigidBody.isKinematic = true;
                        CurrentObjectCollider.enabled = false;


                        //animation
                        animator.SetBool("Has Object", true);
                        hasObjectInHand = true;
                    }
                    else
                    {
                        //PICKUP object
                        CurrentObjectRigidBody = hitInfo.rigidbody;
                        CurrentObjectCollider = hitInfo.collider;

                        CurrentObjectRigidBody.isKinematic = true;
                        CurrentObjectCollider.enabled = false;


                        //animation
                        animator.SetBool("Has Object", true);
                        hasObjectInHand = true;
                    }

                    return;
                }
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
