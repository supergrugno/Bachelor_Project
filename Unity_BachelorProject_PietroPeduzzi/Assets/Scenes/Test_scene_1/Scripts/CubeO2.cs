using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeO2 : MonoBehaviour
{
    [SerializeField] Color[] colors;
    private int colorInOrder = 0;
    private Color actualColor;

    private MeshRenderer objMaterial;

    private void Start()
    {
        objMaterial = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        colorInOrder = ((int)(StaticValues.oxygenInBubble / StaticValues.maxOxygenInBubble * colors.Length));

        if(colorInOrder < colors.Length)
        {
            actualColor = Color.Lerp(objMaterial.material.color, colors[colorInOrder], 0.1f * Time.deltaTime);
            objMaterial.material.color = actualColor;
        }
    }
}
