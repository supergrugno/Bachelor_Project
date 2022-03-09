using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackAnimal_PlayerAsChild : MonoBehaviour
{
    public GameObject playerAsChildSlot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = playerAsChildSlot.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
