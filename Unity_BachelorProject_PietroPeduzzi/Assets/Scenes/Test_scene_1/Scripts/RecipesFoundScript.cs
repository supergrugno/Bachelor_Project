using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecipesFoundScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private GameObject[] recipesToActivate_HardStone;
    [SerializeField] private GameObject[] recipesToActivate_WoodPlanks;
    [SerializeField] private GameObject[] recipesToActivate_Furnace1;
    [SerializeField] private GameObject[] recipesToActivate_Furnace2;
    [SerializeField] private GameObject[] recipesToActivate_O2plant1;
    [SerializeField] private GameObject[] recipesToActivate_O2plant2;
    [SerializeField] private GameObject[] recipesToActivate_O2plant3;
    [SerializeField] private ItemTemplate[] itemsToUnlockrecipe;

    private bool HardStoneFound = false;
    private bool WoodPlanksFound = false;
    private bool Furnace1Found = false;
    private bool Furnace2Found = false;
    private bool O2plant1Found = false;
    private bool O2plant2Found = false;
    private bool O2plant3Found = false;

    [SerializeField] private PlayerInventory playerInventoryReference;

    private void LateUpdate()
    {
        if (playerInventoryReference.CurrentObjectRigidBody != null) CheckForNewItems();
    }

    private void CheckForNewItems()
    {
        //HardStone found
        if(!HardStoneFound && playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item == itemsToUnlockrecipe[0])
        {
            //activate all stone recipes
            foreach (var item in recipesToActivate_HardStone)
            {
                item.SetActive(true);
            }

            HardStoneFound = true;
        }
        //WoodPlanks found
        else if (!WoodPlanksFound && playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item == itemsToUnlockrecipe[1])
        {
            //activate all woodplanks recipes
            foreach (var item in recipesToActivate_WoodPlanks)
            {
                item.SetActive(true);
            }

            WoodPlanksFound = true;
        }
        //Furnace 1 found
        else if (!Furnace1Found && playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item == itemsToUnlockrecipe[2])
        {
            //activate all furnace1 recipes
            foreach (var item in recipesToActivate_Furnace1)
            {
                item.SetActive(true);
            }

            Furnace1Found = true;
        }
        //Furnace 2 found
        else if (!Furnace2Found && playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item == itemsToUnlockrecipe[3])
        {
            //activate all furnace2 recipes
            foreach (var item in recipesToActivate_Furnace2)
            {
                item.SetActive(true);
            }

            Furnace2Found = true;
        }
        //O2 plant 1 found
        else if (!O2plant1Found && playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item == itemsToUnlockrecipe[4])
        {
            //activate all O2plant 1 recipes
            foreach (var item in recipesToActivate_O2plant1)
            {
                item.SetActive(true);
            }

            O2plant1Found = true;
        }
        //O2 plant 2 found
        else if (!O2plant2Found && playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item == itemsToUnlockrecipe[5])
        {
            //activate all O2plant2 recipes
            foreach (var item in recipesToActivate_O2plant2)
            {
                item.SetActive(true);
            }

            O2plant2Found = true;
        }
        //O2 plant 3 found
        else if (!O2plant3Found &&playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item == itemsToUnlockrecipe[6])
        {
            //activate all O2plant3 recipes
            foreach (var item in recipesToActivate_O2plant3)
            {
                item.SetActive(true);
            }

            O2plant3Found = true;
        }
    }
}
