using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotManager : MonoBehaviour
{
    [SerializeField] private SlotManager slotManagerReference;
    [SerializeField] private ItemTemplate O2plantTemplate;
    [SerializeField] private ItemTemplate O2fanTemplate;

    [SerializeField] private float oxygenPusOverTime = 1.5f;
    [SerializeField] private float oxygenMinusOverTime = 1f;

    private void Update()
    {
        if (slotManagerReference.slotIsFull)
        {
            if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().item.itemName == "Plant in a pot")
            {
                StaticValues.oxygenInBubble += Time.fixedDeltaTime * oxygenPusOverTime;
            }
            else if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().item.itemName == "O2 Fan")
            {
                StaticValues.oxygenInBubble -= Time.fixedDeltaTime * oxygenMinusOverTime;
            }
        }
    }
}
