using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeController : MonoBehaviour
{
    [SerializeField] private GameObject[] recipesList;
    private int currentRecipe = 0;
    private bool recipesIsOpen = false;
    private Animator anim;

    private void Start()
    {
        recipesList[currentRecipe].SetActive(true);
        recipesIsOpen = true;
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        OpenCloseRecipes();
        NextRecipe();
    }

    private void OpenCloseRecipes()
    {
        if (Input.GetButtonDown("Recipes"))
        {
            if(recipesIsOpen)
            {
                recipesIsOpen = false;
                anim.SetBool("OpenRecipes", true);
                Time.timeScale = 0;
            }else if (!recipesIsOpen)
            {
                recipesIsOpen = true;
                anim.SetBool("OpenRecipes", false);
                Time.timeScale = 1;
            }
        }
    }

    private void NextRecipe()
    {
        if (Input.GetButtonDown("NextRecipe") && !recipesIsOpen)
        {
            recipesList[currentRecipe].SetActive(false);
            if(currentRecipe == recipesList.Length-1)
            {
                currentRecipe = 0;
                recipesList[currentRecipe].SetActive(true);
            }
            else
            {
                currentRecipe += 1;
                recipesList[currentRecipe].SetActive(true);
            }
        }
    }
}
