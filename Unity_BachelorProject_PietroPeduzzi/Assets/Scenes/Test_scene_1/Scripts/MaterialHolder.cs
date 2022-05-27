using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject Bbutton;

    [SerializeField] private ParticleSystem cloudPS;

    [SerializeField] private GameObject[] visualModel;
    [SerializeField] private GameObject visual_broken;

    private void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerMovementReference = playerObj.GetComponent<PlayerMovement>();

        //itemBlueprint.GetComponent<ItemDisplay>().item = itemProduced;
        foreach (var item in visualModel)
        {
            item.SetActive(false);
        }
        visualModel[Random.Range(0, visualModel.Length)].SetActive(true);
        visual_broken.SetActive(false);
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
                _slider.value = loadBarState/loadBarMax;
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

        CreateCloud();
        _slider.value = 0;

        if (totalMaterialsMined == maxMaterials) EndResources();
    }

    private void CreateCloud()
    {
        cloudPS.Play();
    }

    private void EndResources()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        _player.GetComponent<PlayerMovement>()._canDig = false;
        _player.GetComponent<PlayerMovement>()._isDigging = false;
        _player.GetComponent<PlayerMovement>().animator.SetBool("IsDigging", false);

        Bbutton.SetActive(false);
        foreach (var item in visualModel)
        {
            item.SetActive(false);
        }
        visual_broken.SetActive(true);
    }
}
