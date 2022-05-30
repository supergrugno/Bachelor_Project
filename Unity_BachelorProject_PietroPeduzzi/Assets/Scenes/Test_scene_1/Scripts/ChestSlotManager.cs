using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotManager : MonoBehaviour
{
    [SerializeField] private ItemTemplate O2_plant_broken;
    [SerializeField] private ItemTemplate O2_fan_broken;

    [SerializeField] private SlotManager slotManagerReference;
    [SerializeField] private string O2plantTemplate;

    [SerializeField] private ItemTemplate o2plant_1;
    [SerializeField] private ItemTemplate o2plant_2;
    [SerializeField] private ItemTemplate o2plant_3;

    [SerializeField] private string O2fanTemplate;

    [SerializeField] private float oxygenPusOverTime = 1.5f;
    [SerializeField] private float oxygenMinusOverTime = 1f;

    //SFX
    [SerializeField] private AudioSource airLoopSound;

    private void Start()
    {
        airLoopSound.volume = 0;
    }

    private void Update()
    {
        if (slotManagerReference.slotIsFull)
        {
            if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().item == o2plant_1 ||
                slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().item == o2plant_2 ||
                slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().item == o2plant_3)
            {
                if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().itemDurabilityRemaining > 0)
                {
                    StaticValues.oxygenInBubble += Time.fixedDeltaTime * oxygenPusOverTime;
                    slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().itemDurabilityRemaining -= Time.fixedDeltaTime;
                    airLoopSound.volume = 1;
                }
                else if(slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().itemDurabilityRemaining <= 0)
                {
                    slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().item = O2_plant_broken;
                    slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().ResetItem();
                    airLoopSound.volume = 0;
                }
            }
            else if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().item.itemName == O2fanTemplate)
            {
                if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().itemDurabilityRemaining > 0 && StaticValues.oxygenInBubble > 0)
                {
                    StaticValues.oxygenInBubble -= Time.fixedDeltaTime * oxygenMinusOverTime;
                    slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().itemDurabilityRemaining -= Time.fixedDeltaTime;
                }
                else if (slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().itemDurabilityRemaining <= 0)
                {
                    slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().item = O2_fan_broken;
                    slotManagerReference.slotObjectRigidBody.GetComponent<ItemDisplay>().ResetItem();
                }
            }
        }
    }
}
