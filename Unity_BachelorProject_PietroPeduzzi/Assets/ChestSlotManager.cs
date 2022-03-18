using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotManager : MonoBehaviour
{
    [SerializeField] private SlotManager slotManagerReference;
    [SerializeField] private string O2plantTemplate;
    [SerializeField] private string O2fanTemplate;

    [SerializeField] private float oxygenPusOverTime = 1.5f;
    [SerializeField] private float oxygenMinusOverTime = 1f;

    private void Update()
    {
        if (slotManagerReference.slotIsFull)
        {
            if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().item.itemName == O2plantTemplate)
            {
                if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().itemDurabilityRemaining > 0)
                {
                    StaticValues.oxygenInBubble += Time.fixedDeltaTime * oxygenPusOverTime;
                    slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().itemDurabilityRemaining -= Time.fixedDeltaTime;
                }
            }
            else if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().item.itemName == O2fanTemplate)
            {
                if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().itemDurabilityRemaining > 0)
                {
                    StaticValues.oxygenInBubble -= Time.fixedDeltaTime * oxygenMinusOverTime;
                    slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().itemDurabilityRemaining -= Time.fixedDeltaTime;
                }
            }
        }
    }
}
