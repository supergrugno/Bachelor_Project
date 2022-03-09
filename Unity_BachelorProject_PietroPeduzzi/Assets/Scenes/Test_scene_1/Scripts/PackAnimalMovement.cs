using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackAnimalMovement : MonoBehaviour
{
    [SerializeField] private float animalSpeed;

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * animalSpeed;
    }
}
