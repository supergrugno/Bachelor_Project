using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceO2 : MonoBehaviour
{
    public void ReduceO2InBubble()
    {
        StaticValues.oxygenInBubble -= 10;
        Debug.Log("removed O2");
    }
}
