using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBubble : MonoBehaviour
{
    [SerializeField] PlayerO2Manager playerO2ManagerReference;
    [SerializeField] GameObject O2_BubbleHead;
    private bool playerIsInBubble = false;
    [SerializeField] GameObject vignetteCanvas;

    private void Start()
    {
        playerO2ManagerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerO2Manager>();
        vignetteCanvas.SetActive(false);
    }

    private void Update()
    {
        if (playerIsInBubble && StaticValues.oxygenOnPlayer < playerO2ManagerReference.playerMaxOxygen)
        {
            StaticValues.oxygenOnPlayer = playerO2ManagerReference.playerMaxOxygen;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsInBubble = true;
            O2_BubbleHead.GetComponent<Animator>().SetTrigger("Deactivate");
            vignetteCanvas.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsInBubble = false;
            O2_BubbleHead.GetComponent<Animator>().SetTrigger("Activate");
            vignetteCanvas.SetActive(true);
        }
    }
}
