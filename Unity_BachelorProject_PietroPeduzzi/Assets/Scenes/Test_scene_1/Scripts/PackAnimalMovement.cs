using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackAnimalMovement : MonoBehaviour
{
    [SerializeField] private float animalSpeed_0 = 0.3f;
    [SerializeField] private float animalSpeed_1 = 0.6f;
    [SerializeField] private float animalSpeed_2 = 0.9f;

    [SerializeField] private float distance_0 = 0.3f;
    [SerializeField] private float distance_1 = 0.6f;
    [SerializeField] private float distance_2 = 0.9f;

    private float actualAnimalSpeed = 0;
    [SerializeField] private O2ManagerBubble o2ManagerBubbleReference;

    private float startXPosition;

    private void Start()
    {
        startXPosition = gameObject.transform.position.x;
    }

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * actualAnimalSpeed;
        if (o2ManagerBubbleReference.playerCompletedTutorial)
        {
            if (StaticValues.distanceTraveled < distance_0) actualAnimalSpeed = animalSpeed_0;
            if (StaticValues.distanceTraveled >= distance_0 && StaticValues.distanceTraveled < distance_2) actualAnimalSpeed = animalSpeed_1;
            if (StaticValues.distanceTraveled >= distance_2 && StaticValues.distanceTraveled < 350) actualAnimalSpeed = animalSpeed_2;
        }

        StaticValues.distanceTraveled = gameObject.transform.position.x - startXPosition;
    }
}
