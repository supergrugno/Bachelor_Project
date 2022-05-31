using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBubble : MonoBehaviour
{
    [SerializeField] PlayerO2Manager playerO2ManagerReference;
    [SerializeField] GameObject O2_BubbleHead;
    private bool playerIsInBubble = false;
    [SerializeField] GameObject vignetteCanvas;
    [SerializeField] private AudioSource entrySound;
    [SerializeField] private AudioSource exitSound;

    [SerializeField] private AudioSource breathingSound;

    private void Start()
    {
        playerO2ManagerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerO2Manager>();
        vignetteCanvas.SetActive(false);
        breathingSound.volume = 0;
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
            entrySound.pitch = Random.Range(0.8f, 1.1f);
            entrySound.Play();
            breathingSound.volume = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsInBubble = false;
            O2_BubbleHead.GetComponent<Animator>().SetTrigger("Activate");
            vignetteCanvas.SetActive(true);
            exitSound.pitch = Random.Range(0.8f, 1.1f);
            exitSound.Play();
            breathingSound.volume = 0.3f;
        }
    }
}
