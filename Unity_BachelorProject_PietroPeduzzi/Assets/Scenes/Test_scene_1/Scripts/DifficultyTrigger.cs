using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyTrigger : MonoBehaviour
{
    public float newOxygenUsage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerO2Manager>().oxygenDeploySpeed = newOxygenUsage;
        }
    }
}
