using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2Animal_Bubble : MonoBehaviour
{
    [SerializeField] private float maxSize = 1;
    [SerializeField] private float minSize = 0.3f;
    private float actualSize = 1;

    public O2ManagerBubble o2ManagerBubbleReference;

    public GameObject O2_bubble;


    private void Update()
    {
        actualSize = maxSize / o2ManagerBubbleReference.maxOxygen * StaticValues.oxygenInBubble;
        if (actualSize > minSize)
        {
            gameObject.transform.localScale = new Vector3(actualSize, actualSize, actualSize);
        }
        else if (actualSize <= minSize)
        {
            actualSize = minSize;
            gameObject.transform.localScale = new Vector3(actualSize, actualSize, actualSize);
        }
    }
}
