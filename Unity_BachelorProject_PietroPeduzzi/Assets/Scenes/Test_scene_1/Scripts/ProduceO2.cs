using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceO2 : MonoBehaviour
{
    [SerializeField] private GameObject O2smokePS;

    public void ProduceO2InBubble()
    {
        StaticValues.oxygenInBubble += 10;
        Debug.Log("added O2");
        Instantiate(O2smokePS, transform.position, Quaternion.identity);

    }
}
