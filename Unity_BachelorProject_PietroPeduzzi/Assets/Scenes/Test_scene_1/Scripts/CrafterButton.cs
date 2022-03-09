using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrafterButton : MonoBehaviour
{
    public UnityEvent ifButtonIsPressedEvent;

    [SerializeField] private float NecessaryPressTime = 2;
    private float actualTimePressed;
    private bool buttonHasBeenPressed = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player.GetComponent<PlayerMovement>()._isPressingButton)
        {
            actualTimePressed += Time.deltaTime;
            if (actualTimePressed >= NecessaryPressTime && buttonHasBeenPressed == false)
            {
                ifButtonIsPressedEvent.Invoke();
                buttonHasBeenPressed = true;
            }
        }
        else if (!player.GetComponent<PlayerMovement>()._isPressingButton)
        {
            actualTimePressed = 0;
            buttonHasBeenPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") other.GetComponent<PlayerMovement>()._canPressButton = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") other.GetComponent<PlayerMovement>()._canPressButton = false;
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject player = other.gameObject;
            if (player.GetComponent<PlayerMovement>()._isPressingButton)
            {
                actualTimePressed += Time.deltaTime;
                if(actualTimePressed >= NecessaryPressTime && buttonHasBeenPressed == false)
                {
                    ifButtonIsPressedEvent.Invoke();
                    buttonHasBeenPressed = true;
                }
            }else if (!player.GetComponent<PlayerMovement>()._isPressingButton)
            {
                actualTimePressed = 0;
                buttonHasBeenPressed = false;
            }
        }
    }*/
}
