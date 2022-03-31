using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerItemDescription : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventoryReference;
    [SerializeField] private GameObject descriptionCanvas;
    private bool descriptionCanvasIsActive = false;
    [SerializeField] private TextMeshProUGUI itemDescription;

    private void Start()
    {
        descriptionCanvasIsActive = false;
        descriptionCanvas.SetActive(false);
    }
    private void Update()
    {
        if(playerInventoryReference.hasObjectInHand) itemDescription.text = playerInventoryReference.CurrentObjectRigidBody.gameObject.GetComponent<ItemDisplay>().item.itemDescription;
        ShowItemDescription();
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
