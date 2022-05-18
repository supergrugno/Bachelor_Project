using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHP : MonoBehaviour
{
    [SerializeField] private float cubeHPborder = 1;
    [SerializeField] private Material red;
    [SerializeField] private Material black;

    private MeshRenderer cubeMat;

    private void Start()
    {
        cubeMat = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (StaticValues.playerHP < cubeHPborder) cubeMat.material = black;
        else if (StaticValues.playerHP >= cubeHPborder) cubeMat.material = red;
    }
}
