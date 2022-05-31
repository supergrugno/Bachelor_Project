using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftAnimator : MonoBehaviour
{
    [SerializeField] private GameObject pointDown;
    [SerializeField] private GameObject pointUp;

    [SerializeField] private float platformSpeed = 1;

    private bool playerIsOnPlatform = false;

    [SerializeField] private AudioSource pulleySound;

    private void Update()
    {
        if(playerIsOnPlatform) transform.position = Vector3.MoveTowards(transform.position, pointUp.transform.position, platformSpeed * Time.deltaTime);
        else transform.position = Vector3.MoveTowards(transform.position, pointDown.transform.position, platformSpeed * 1.5f * Time.deltaTime);

        if(transform.position == pointDown.transform.position || transform.position == pointUp.transform.position)
        {
            pulleySound.volume = 0;
        }
        else
        {
            pulleySound.volume = 0.6f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") playerIsOnPlatform = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") playerIsOnPlatform = false;
    }
}
