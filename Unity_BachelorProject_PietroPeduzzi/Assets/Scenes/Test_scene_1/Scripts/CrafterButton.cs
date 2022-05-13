using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CrafterButton : MonoBehaviour
{
    [SerializeField] private UnityEvent ifButtonIsPressedEvent;
    public ReduceO2 ReduceO2reference;

    [SerializeField] private float NecessaryPressTime = 2;
    private float actualTimePressed;
    private bool playerIsOnThisButton = false;
    private bool buttonHasBeenPressed = false;
    private GameObject player;

    //animation
    private Animator animatorRef;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animatorRef = this.gameObject.GetComponent<Animator>();
        animatorRef.enabled = false;
    }

    private void Update()
    {
        if (player.GetComponent<PlayerMovement>()._isPressingButton)
        {
            actualTimePressed += Time.deltaTime;
            if (actualTimePressed >= NecessaryPressTime && buttonHasBeenPressed == false && playerIsOnThisButton)
            {
                ifButtonIsPressedEvent.Invoke();
                buttonHasBeenPressed = true;
            }

            animatorRef.SetBool("IsBeingPressed", true);
        }
        else if (!player.GetComponent<PlayerMovement>()._isPressingButton)
        {
            actualTimePressed = 0;
            buttonHasBeenPressed = false;
            animatorRef.SetBool("IsBeingPressed", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>()._canPressButton = true;
            playerIsOnThisButton = true;
            animatorRef.enabled = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMovement>()._canPressButton = false;
            playerIsOnThisButton = false;
            animatorRef.enabled = false;
        }
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
