using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class CrafterManager : MonoBehaviour
{
    public CraftingRecipesTemplate[] recipes;

    public GameObject[] itemSlots;
    public bool crafterIsFull = false;
    private int fullSlotsCounter = 0;

    public ItemTemplate[] _itemsInSlot;
    public ItemTemplate[] _itemsInSlotVoid;

    private bool recepyIsCorrect = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CompleteRecepy();
            ClearArray();
        }
    }

    public void CompleteRecepy()
    {
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
            Debug.Log("Crafter is full");
            CheckRecepy();
        }
        else
        {
            Debug.Log("Crafter need to be filled");
        }
    }
    
    private void CheckRecepy()
    {
        foreach (var item in recipes)
        {
            bool isEqual = item.itemsNeeded.SequenceEqual(_itemsInSlot);
            if (isEqual)
            {
                Debug.Log("AAAAAAAAAAAAAAAAAAAAAA--------------------------------------------------------------");
            }
        }
    }

    private void ClearArray()
    {
        _itemsInSlot = _itemsInSlotVoid;
    }

}
