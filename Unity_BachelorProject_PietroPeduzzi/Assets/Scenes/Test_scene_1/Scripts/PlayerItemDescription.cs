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

    private void Start()
    {
        descriptionCanvasIsActive = false;
        descriptionCanvas.SetActive(false);
    }
    private void Update()
    {
        if (playerInventoryReference.hasObjectInHand)
        {
            //itemDescription.text = playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item.itemDescription;
            itemSprite.sprite = playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item.itemIcon;
        }
        
        ShowItemDescription();
        if(playerInventoryReference.hasObjectInHand == false)
        {
            descriptionCanvas.SetActive(false);
            descriptionCanvasIsActive = false;
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
}
