using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTransposer : MonoBehaviour
{
    public float newXPoint = 100;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rock") other.transform.position = new Vector3(other.transform.position.x + newXPoint, other.transform.position.y, other.transform.position.z);
    }
}
