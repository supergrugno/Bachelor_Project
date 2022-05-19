using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerItemDescription : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventoryReference;
    [SerializeField] private GameObject descriptionCanvas;
    private bool descriptionCanvasIsActive = false;
    //[SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private Image itemSprite;
    [SerializeField] private GameObject itemNameTextGameObject;
    [SerializeField] private TextMeshProUGUI itemNameText;
    private string itemNamePlaceHolderText;

    private void Start()
    {
        descriptionCanvasIsActive = false;
        descriptionCanvas.SetActive(false);
        itemNamePlaceHolderText = itemNameText.text;
    }
    private void Update()
    {
        if (playerInventoryReference.hasObjectInHand)
        {
            //itemDescription.text = playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item.itemDescription;
            itemSprite.sprite = playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item.itemIcon;

            ShowItemName();
        }
        
        ShowItemDescription();
        if(playerInventoryReference.hasObjectInHand == false)
        {
            descriptionCanvas.SetActive(false);
            descriptionCanvasIsActive = false;
            itemNameText.text = "";
        }
    }

    private void ShowItemDescription()
    {
        if(Input.GetButtonDown("Inspect") && playerInventoryReference.hasObjectInHand)
        {
            if (!descriptionCanvasIsActive)
            {
                descriptionCanvas.SetActive(true);
                descriptionCanvasIsActive = true;
            }else if (descriptionCanvasIsActive)
            {
                descriptionCanvas.SetActive(false);
                descriptionCanvasIsActive = false;
            }

        }
    }

    private void ShowItemName()
    {
        itemNamePlaceHolderText = playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item.itemName;
        if (itemNamePlaceHolderText != itemNameText.text)
        {
            //play animation
            itemNameTextGameObject.GetComponent<Animator>().SetTrigger("TextAnimation");

            itemNameText.text = itemNamePlaceHolderText;
        }
    }
}
