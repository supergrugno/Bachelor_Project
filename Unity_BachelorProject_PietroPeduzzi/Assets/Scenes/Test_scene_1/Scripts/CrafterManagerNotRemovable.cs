using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class CrafterManagerNotRemovable : MonoBehaviour
{
    //visual recipes 
    private bool recipesIsActive;
    [SerializeField] private GameObject recipeList;
    private bool isOnCrafter;



    private void Start()
    {
        recipesIsActive = false;
        isOnCrafter = false;
        recipeList.SetActive(false);
    }

    private void Update()
    {
        ShowRecipes();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isOnCrafter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isOnCrafter = false;
        }
    }

    private void ShowRecipes()
    {
        if (isOnCrafter && Input.GetButtonDown("Inspect"))
        {
            if (!recipesIsActive)
            {
                recipeList.SetActive(true);
                recipesIsActive = true;
            }
            else if (recipesIsActive)
            {
                recipeList.SetActive(false);
                recipesIsActive = false;
            }
        }
        else if (!isOnCrafter)
        {
            recipeList.SetActive(false);
            recipesIsActive = false;
        }
    }
}
