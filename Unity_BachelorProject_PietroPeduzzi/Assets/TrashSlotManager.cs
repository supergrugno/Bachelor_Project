using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSlotManager : MonoBehaviour
{
    [SerializeField] private SlotManager slotManagerReference;

    public void TrashObject()
    {
        if(slotManagerReference.slotObjectRigidBody != null)
        {
            Destroy(slotManagerReference.slotObjectRigidBody.gameObject);

            slotManagerReference.slotIsFull = false;
            slotManagerReference.slotObjectRigidBody = null;
            slotManagerReference.slotObjectCollider = null;
        }
    }
}
