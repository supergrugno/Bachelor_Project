using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialHolder : MonoBehaviour
{
    [SerializeField] private GameObject itemBlueprint;
    [SerializeField] private ItemTemplate itemProduced;

    private GameObject playerObj;
    private PlayerMovement playerMovementReference;

    public int maxMaterials = 2;
    private int totalMaterialsMined = 0;

    public float loadBarMax = 5;
    private float loadBarState = 0;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerMovementReference = playerObj.GetComponent<PlayerMovement>();

        //itemBlueprint.GetComponent<ItemDisplay>().item = itemProduced;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") other.GetComponent<PlayerMovement>()._canDig = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") other.GetComponent<PlayerMovement>()._canDig = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == playerObj && totalMaterialsMined < maxMaterials)
        {
            if (playerMovementReference._isDigging)
            {
                loadBarState += Time.deltaTime * StaticValues.miningSpeed;
                if(loadBarState >= loadBarMax)
                {
                    DropReource();
                    loadBarState = 0;
                }
            }
        }
    }

    private void DropReource()
    {
        Debug.Log("Material has been created");
        totalMaterialsMined += 1;

        GameObject newItem = Instantiate(itemBlueprint, new Vector3(transform.position.x, transform.position.y + 0.5f, 50), Quaternion.identity);
        newItem.GetComponent<ItemDisplay>().item = itemProduced;
        newItem.GetComponent<Rigidbody>().AddForce((gameObject.transform.right + gameObject.transform.up), ForceMode.Impulse);
    }
}
