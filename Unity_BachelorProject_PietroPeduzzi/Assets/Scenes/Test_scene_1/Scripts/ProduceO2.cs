using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceO2 : MonoBehaviour
{
    public void ProduceO2InBubble()
    {
        StaticValues.oxygenInBubble += 10;
        Debug.Log("added O2");
    }
}
