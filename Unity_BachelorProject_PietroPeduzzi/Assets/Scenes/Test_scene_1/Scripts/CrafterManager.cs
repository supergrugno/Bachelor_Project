using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CrafterManager : MonoBehaviour
{
    //blanck item for result
    [SerializeField] private GameObject itemBlueprint;

    //list of all recipes the crafter can handle
    public CraftingRecipesTemplate[] recipes;

    //list of slots the crafter has and other variables for organisation
    public GameObject[] itemSlots;
    public bool crafterIsFull = false;
    private int fullSlotsCounter = 0;

    //list used to group all items in all slots and list used to reset the first list to empty
    public ItemTemplate[] _itemsInSlot;
    public ItemTemplate[] _itemsInSlotVoid;

    private bool recepyIsCorrect = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CompleteRecepy();
            //after each check the items array is reset
            //items in the array will appear in same order as the item slots that contain them
            ClearArray();
        }
    }

    public void CompleteRecepy()
    {
        //here the crafter checks if all slots are full
        fullSlotsCounter = 0;
        foreach (var item in itemSlots)
        {
            if (item.GetComponent<SlotManager>().slotIsFull)
            {
                fullSlotsCounter += 1;
                _itemsInSlot = new List<ItemTemplate>(_itemsInSlot) { item.GetComponent<SlotManager>().itemInSlot }.ToArray();
            }
        }
        if (fullSlotsCounter == itemSlots.Length)
        {
            //if all crafter slots are full the crafter checks the recepies
            Debug.Log("Crafter is full");
            CheckRecepy();
        }
        else
        {
            //if the crafter is not full nothing happens
            Debug.Log("Crafter need to be filled");
        }
    }
    
    private void CheckRecepy()
    {
        //crafter goes thru all recipes and checks if they have the needed elements
        foreach (var item in recipes)
        {
            bool isEqual = item.itemsNeeded.SequenceEqual(_itemsInSlot);
            //if the elements in the crafter are the same as a recepy the slots gets emptyed and a new item is created
            if (isEqual)
            {
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAA--------------------------------------------------------------");
                foreach (var item3 in itemSlots)
                {
                    SlotManager slotRB = item3.GetComponent<SlotManager>();
                    Destroy(slotRB.slotObjectRigidBody.gameObject);

                    //slot gets reset after removing the materials
                    slotRB.slotIsFull = false;
                    slotRB.slotObjectRigidBody = null;
                    slotRB.slotObjectCollider = null;
                }
                //new item is created by reading the recepy and adding the ItemTemplate object to the blueprint prefab
                GameObject newItem = Instantiate(itemBlueprint, new Vector3(transform.position.x, transform.position.y, 50), Quaternion.identity);
                newItem.GetComponent<ItemDisplay>().item = recipes[System.Array.IndexOf(recipes, item)].itemResult;
            }
        }
    }

    private void ClearArray()
    {
        //here the items array gets reset to empty
        _itemsInSlot = _itemsInSlotVoid;
    }

}
