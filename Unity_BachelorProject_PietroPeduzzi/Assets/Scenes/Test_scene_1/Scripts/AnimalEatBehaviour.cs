using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalEatBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject foodSlot;
    private Animator foodSlotAnimator;
    private ItemTemplate itemOnFoodSlot;

    private bool eatingInProgress = false;
    private bool foundGoodFoodItem = false;

    [SerializeField] private float minEatingTime = 4;
    [SerializeField] private float maxEatingTime = 16;
    private float eatingTime;

    [SerializeField] private List<ItemTemplate> GoodFoodItems;

    [SerializeField] private PackAnimalMovement packAnimalMovementRef;

    private void Start()
    {
        foodSlotAnimator = foodSlot.GetComponent<Animator>();
        itemOnFoodSlot = foodSlot.GetComponent<SlotManager>().itemInSlot;
    }

    private void LateUpdate()
    {
        if (foodSlot.GetComponent<SlotManager>().slotIsFull && !eatingInProgress)
        {
            FeedAnimal();
        }

        if (eatingInProgress)
        {
            StaticValues.oxygenInBubble += Time.fixedDeltaTime;
        }
    }

    private void FeedAnimal()
    {
        itemOnFoodSlot = foodSlot.GetComponent<SlotManager>().itemInSlot;
        if (GoodFoodItems.Contains(itemOnFoodSlot))
        {
            eatingInProgress = true;
            FoodIsGood();
        }
    }

    private void ResetRope()
    {
        foodSlotAnimator.SetBool("AnimalIsEating", false);

        Destroy(foodSlot.GetComponent<SlotManager>().slotObjectRigidBody.gameObject);
        foodSlot.GetComponent<SlotManager>().slotObjectRigidBody = null;
        foodSlot.GetComponent<SlotManager>().slotObjectCollider = null;
        foodSlot.GetComponent<SlotManager>().slotIsFull = false;

        foundGoodFoodItem = false;
        packAnimalMovementRef.animalCanMove = true;
        eatingInProgress = false;
    }

    private void FoodIsGood()
    {
        foodSlotAnimator.SetBool("AnimalIsEating", true);
        eatingTime = Random.Range(minEatingTime, maxEatingTime);
        packAnimalMovementRef.animalCanMove = false;

        Invoke("ResetRope", eatingTime);
    }


}
