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

    public Rigidbody CurrentObjectRigidBody;
    //public Rigidbody LastCurrentObjectRigidBody;
    public Collider CurrentObjectCollider;

    private Rigidbody floatingRigidBody = null;
    private Collider floatingCollider = null;


    //animations
    public Animator animator;
    public bool hasObjectInHand;

    //other
    //[SerializeField] private LayerMask checkXLayer;
    private GameObject lastObjCheckX;

    //SFX
    [SerializeField] private AudioSource pickupSound;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void LateUpdate()
    {
        CheckDirection();
        GetObject();
        DeadDrop();
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
                    //LastCurrentObjectRigidBody = CurrentObjectRigidBody;

                    CurrentObjectRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;

                    CurrentObjectRigidBody = hitInfo_1.rigidbody;
                    CurrentObjectCollider = hitInfo_1.collider;

                    CurrentObjectRigidBody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;

                    CurrentObjectRigidBody.constraints = RigidbodyConstraints.None;

                    //animation
                    animator.SetBool("Has Object", true);
                    animator.SetTrigger("PickUp");
                    hasObjectInHand = true;

                    pickupSound.pitch = Random.Range(0.8f, 1);
                    pickupSound.Play();
                }
                else
                {
                    //PICKUP object
                    CurrentObjectRigidBody = hitInfo_1.rigidbody;
                    CurrentObjectCollider = hitInfo_1.collider;

                    CurrentObjectRigidBody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;

                    CurrentObjectRigidBody.constraints = RigidbodyConstraints.None;

                    //animation
                    animator.SetBool("Has Object", true);
                    animator.SetTrigger("PickUp");
                    hasObjectInHand = true;

                    pickupSound.pitch = Random.Range(0.8f, 1);
                    pickupSound.Play();
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

                    CurrentObjectRigidBody.constraints = RigidbodyConstraints.None;

                    CurrentObjectRigidBody = null;
                    CurrentObjectCollider = null;

                    //animation
                    animator.SetBool("Has Object", false);
                    hasObjectInHand = false;

                    pickupSound.pitch = Random.Range(0.5f, 0.8f);
                    pickupSound.Play();
                }
                else if(!CurrentObjectRigidBody && slotReference.slotIsFull == true)
                {
                    //Debug.Log("took item from crafer");

                    CurrentObjectRigidBody = slotReference.slotObjectRigidBody;
                    CurrentObjectCollider = slotReference.slotObjectCollider;

                    CurrentObjectRigidBody.isKinematic = true;
                    CurrentObjectCollider.enabled = false;

                    CurrentObjectRigidBody.constraints = RigidbodyConstraints.None;

                    slotReference.slotObjectRigidBody = null;
                    slotReference.slotObjectCollider = null;

                    //animation
                    animator.SetBool("Has Object", true);
                    animator.SetTrigger("PickUp");
                    hasObjectInHand = true;

                    pickupSound.pitch = Random.Range(0.8f, 1);
                    pickupSound.Play();

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

                    CurrentObjectRigidBody.constraints = RigidbodyConstraints.None;

                    slotReference.slotObjectRigidBody = floatingRigidBody;
                    slotReference.slotObjectCollider = floatingCollider;

                    slotReference.slotObjectRigidBody.isKinematic = true;
                    slotReference.slotObjectCollider.enabled = false;

                    CurrentObjectRigidBody.constraints = RigidbodyConstraints.None;

                    floatingRigidBody = null;
                    floatingCollider = null;

                    //animation
                    animator.SetBool("Has Object", true);
                    animator.SetTrigger("PickUp");
                    hasObjectInHand = true;

                    pickupSound.pitch = Random.Range(0.8f, 1);
                    pickupSound.Play();
                }

                 return;
            }
            

            // DROP object
            if (CurrentObjectRigidBody)
            {
                CurrentObjectRigidBody.isKinematic = false;
                CurrentObjectCollider.enabled = true;
                //LastCurrentObjectRigidBody = CurrentObjectRigidBody;

                CurrentObjectRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;

                //animation
                animator.SetBool("Has Object", false);
                hasObjectInHand = false;

                pickupSound.pitch = Random.Range(0.5f, 0.8f);
                pickupSound.Play();

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
                //LastCurrentObjectRigidBody = CurrentObjectRigidBody;

                CurrentObjectRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;

                if (StaticValues.isLookingRight == true) CurrentObjectRigidBody.AddForce((Hand.right + Hand.up) * throwingForce, ForceMode.Impulse);
                else if (StaticValues.isLookingRight == false) CurrentObjectRigidBody.AddForce((-Hand.right + Hand.up) * throwingForce, ForceMode.Impulse);


                //animation
                animator.SetBool("Has Object", false);
                hasObjectInHand = false;

                pickupSound.pitch = Random.Range(0.5f, 0.8f);
                pickupSound.Play();

                CurrentObjectRigidBody = null;
                CurrentObjectCollider = null;
            }
        }

        if (Input.GetButtonDown("Consume"))
        {
            if(CurrentObjectRigidBody != null)
            {
                if (CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item.isEdible && StaticValues.playerHP < StaticValues.maxPlayerHP)
                {
                    float hpDifference = StaticValues.maxPlayerHP - StaticValues.playerHP;
                    float itemFoodLevel = CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item.itemDurability;

                    if (hpDifference > itemFoodLevel) StaticValues.playerHP += itemFoodLevel;
                    else if (hpDifference <= itemFoodLevel) StaticValues.playerHP = StaticValues.maxPlayerHP;

                    Debug.Log("food eaten");

                    //animation
                    animator.SetBool("Has Object", false);
                    hasObjectInHand = false;

                    pickupSound.pitch = Random.Range(0.5f, 0.8f);
                    pickupSound.Play();

                    Destroy(CurrentObjectRigidBody.gameObject);
                    CurrentObjectRigidBody = null;
                    CurrentObjectCollider = null;
                }
            }
        }

        if (CurrentObjectRigidBody)
        {
            CurrentObjectRigidBody.position = Hand.position;
            CurrentObjectRigidBody.rotation = Hand.rotation;
        }
    }


    private void DeadDrop()
    {
        if (StaticValues.playerIsDead)
        {
            if (CurrentObjectRigidBody)
            {
                CurrentObjectRigidBody.isKinematic = false;
                CurrentObjectCollider.enabled = true;
                //LastCurrentObjectRigidBody = CurrentObjectRigidBody;

                CurrentObjectRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;

                //animation
                animator.SetBool("Has Object", false);
                hasObjectInHand = false;

                pickupSound.pitch = Random.Range(0.5f, 0.8f);
                pickupSound.Play();

                CurrentObjectRigidBody = null;
                CurrentObjectCollider = null;
            }
        }
    }
}
