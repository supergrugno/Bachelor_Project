using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public bool slotIsFull = false;

    public Rigidbody slotObjectRigidBody;
    public Collider slotObjectCollider;

    public ItemTemplate itemInSlot;

    private void Update()
    {
        if (slotObjectRigidBody)
        {
            slotObjectRigidBody.position = this.transform.position;
            slotObjectRigidBody.rotation = this.transform.rotation;

            itemInSlot = slotObjectRigidBody.GetComponent<ItemDisplay>().item;
        }
    }
}
