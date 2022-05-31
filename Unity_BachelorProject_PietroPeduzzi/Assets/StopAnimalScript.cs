using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimalScript : MonoBehaviour
{
    [SerializeField] private GameObject animalGameObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AnimalEye")
        {
            animalGameObject.GetComponent<PackAnimalMovement>().animalCanMove = false;
        }
    }
}
