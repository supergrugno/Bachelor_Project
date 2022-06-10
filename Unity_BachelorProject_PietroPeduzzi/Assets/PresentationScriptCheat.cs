using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationScriptCheat : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Transform TP1;
    [SerializeField] private Transform TP2;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            player.transform.position = TP1.transform.position;
            player.GetComponent<PlayerO2Manager>().oxygenDeploySpeed = 0;
        }
            
            
        if (Input.GetKeyDown(KeyCode.L))
        {
            player.transform.position = TP2.transform.position;
            player.GetComponent<PlayerO2Manager>().oxygenDeploySpeed = 0;
        }
    }
}
