using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2ManagerBubble : MonoBehaviour
{
    [SerializeField] private float BubbleStartOxygen = 100;
    [SerializeField] private float maxOxygen = 200;

    [SerializeField] PlayerO2Manager playerO2ManagerReference;
    [SerializeField] GameObject O2_BubbleHead;
    private bool playerIsInBubble = false;

    public bool playerCompletedTutorial = false;

    private void Start()
    {
        StaticValues.oxygenInBubble = BubbleStartOxygen;
        playerO2ManagerReference = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerO2Manager>();
    }

    private void Update()
    {
            playerO2ManagerReference.OxygenUsage();
            playerO2ManagerReference.HPDeploy();
            RefillPlayerO2();
    }

    private void RefillPlayerO2()
    {
        if(playerIsInBubble && StaticValues.oxygenOnPlayer < playerO2ManagerReference.playerMaxOxygen && playerCompletedTutorial)
        {
            float O2added = playerO2ManagerReference.playerMaxOxygen - StaticValues.oxygenOnPlayer;
            if(StaticValues.oxygenInBubble - O2added >= 0)
            {
                StaticValues.oxygenOnPlayer += O2added;
                StaticValues.oxygenInBubble -= O2added;
            }else if(StaticValues.oxygenInBubble - O2added < 0)
            {
                StaticValues.oxygenOnPlayer += StaticValues.oxygenInBubble;
                StaticValues.oxygenInBubble -= StaticValues.oxygenInBubble;
            }
        }else if(playerIsInBubble && StaticValues.oxygenOnPlayer < playerO2ManagerReference.playerMaxOxygen && !playerCompletedTutorial)
        {
            StaticValues.oxygenOnPlayer = playerO2ManagerReference.playerMaxOxygen;
            if (StaticValues.oxygenInBubble == maxOxygen) playerCompletedTutorial = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsInBubble = true;
            O2_BubbleHead.GetComponent<Animator>().SetTrigger("Deactivate");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsInBubble = false;
            O2_BubbleHead.GetComponent<Animator>().SetTrigger("Activate");
        }
    }
}
