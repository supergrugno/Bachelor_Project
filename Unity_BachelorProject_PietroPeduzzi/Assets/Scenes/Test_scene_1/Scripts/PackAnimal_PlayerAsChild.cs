using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackAnimal_PlayerAsChild : MonoBehaviour
{
    public GameObject playerAsChildSlot;
    public bool playerIsOnAnimal;
    public bool playerHasParent;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (playerIsOnAnimal && !playerHasParent)
        {
            player.transform.parent = playerAsChildSlot.transform;
            playerHasParent = true;
        }else if(!playerIsOnAnimal && playerHasParent)
        {
            player.transform.parent = null;
            playerHasParent = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOnAnimal = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") playerIsOnAnimal = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !playerIsOnAnimal)
        {
            playerIsOnAnimal = false;
        }
        else
        {
            playerIsOnAnimal = false;
        }
    }
}
