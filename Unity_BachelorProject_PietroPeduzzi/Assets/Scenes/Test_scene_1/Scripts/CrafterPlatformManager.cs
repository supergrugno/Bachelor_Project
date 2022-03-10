using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrafterPlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject crafterPositionEmptyObj;
    private bool canPlaceCrafter = false;
    public bool platformIsFull = false;
    private GameObject playerReference;
    private PlayerInventory playerInventoryReference;


    private void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        playerInventoryReference = playerReference.GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (canPlaceCrafter && platformIsFull == false && Input.GetButtonDown("Interact") && playerInventoryReference.CurrentObjectRigidBody != null) PlaceCrafter();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") canPlaceCrafter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") canPlaceCrafter = false;
    }

    private void PlaceCrafter()
    {
        if (playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item.crafterPrefab != null)
        {
            Debug.Log("Placed Crafter");
            GameObject _crafter = Instantiate(playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item.crafterPrefab, crafterPositionEmptyObj.transform.position, Quaternion.identity);
            _crafter.transform.parent = crafterPositionEmptyObj.transform;
            Destroy(playerInventoryReference.CurrentObjectRigidBody.gameObject);

            playerInventoryReference.animator.SetBool("Has Object", false);
            playerInventoryReference.hasObjectInHand = false;
            playerInventoryReference.CurrentObjectRigidBody = null;
            playerInventoryReference.CurrentObjectCollider = null;

            platformIsFull = true;
        }
    }
}
