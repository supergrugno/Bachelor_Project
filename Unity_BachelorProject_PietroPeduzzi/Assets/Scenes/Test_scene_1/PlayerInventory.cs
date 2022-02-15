using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //animations
    private Animator animator;
    private bool hasObjectInHand;


    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        GetObject();
    }

    private void GetObject()
    {


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (hasObjectInHand == false)
            {
                animator.SetBool("Has Object", true);
                hasObjectInHand = true;
            }
            else if (hasObjectInHand == true)
            {
                animator.SetBool("Has Object", false);
                hasObjectInHand = false;
            }
        }
    }
}
