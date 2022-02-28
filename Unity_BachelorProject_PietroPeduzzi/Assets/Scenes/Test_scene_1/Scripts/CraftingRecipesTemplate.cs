using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Recepy", menuName = "Recepy SO")]
public class CraftingRecipesTemplate : ScriptableObject
{
    public string recepyName;
    public ItemTemplate[] itemsNeeded;

    public ItemTemplate itemResult;
}
