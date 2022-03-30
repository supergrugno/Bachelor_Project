using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackAnimalMovement : MonoBehaviour
{
    [SerializeField] private float animalSpeed;
    private float actualAnimalSpeed = 0;
    [SerializeField] private O2ManagerBubble o2ManagerBubbleReference;

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * actualAnimalSpeed;
        if (o2ManagerBubbleReference.playerCompletedTutorial)
        {
            actualAnimalSpeed = animalSpeed;
        }
    }
}
