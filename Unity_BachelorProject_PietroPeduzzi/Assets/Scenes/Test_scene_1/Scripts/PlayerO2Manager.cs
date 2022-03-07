using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerO2Manager : MonoBehaviour
{
    [SerializeField] private float playerStartOxygen = 10;
    [SerializeField] public float playerMaxOxygen = 10;
    [SerializeField] private float oxygenDeploySpeed = 1;

    private void Start()
    {
        StaticValues.oxygenOnPlayer = playerStartOxygen;
    }

    public void OxygenUsage()
    {
        StaticValues.oxygenOnPlayer -= Time.deltaTime / oxygenDeploySpeed;
    }
}
