using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O2PlayerBubble : MonoBehaviour
{
    [SerializeField] private float maxSize = 1;
    [SerializeField] private float minSize = 0.3f;
    private float actualSize = 1;

    public PlayerO2Manager playerO2ManagerReference;

    public GameObject O2_bubble;
    private Renderer _renderer;

    private void Start()
    {
        _renderer = O2_bubble.GetComponent<Renderer>();
    }

    private void Update()
    {
        actualSize = maxSize / playerO2ManagerReference.playerMaxOxygen * StaticValues.oxygenOnPlayer;
        if (actualSize > minSize)
        {
            gameObject.transform.localScale = new Vector3(actualSize, actualSize, actualSize);
        }
        else if(actualSize <= minSize)
        {
            actualSize = minSize; 
            gameObject.transform.localScale = new Vector3(actualSize, actualSize, actualSize);
        }
    }
}
