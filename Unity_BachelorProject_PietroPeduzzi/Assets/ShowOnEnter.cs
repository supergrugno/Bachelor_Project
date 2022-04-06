using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnEnter : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject text_1;
    [SerializeField] private GameObject text_2;

    [SerializeField] private GameObject platform;

    private void Start()
    {
        _canvas.SetActive(false);
        text_2.SetActive(false);
    }

    private void Update()
    {
        if(platform.transform.childCount == 0)
        {
            text_1.SetActive(false);
            text_2.SetActive(true);
        }else if(platform.transform.childCount != 0)
        {
            text_1.SetActive(true);
            text_2.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") _canvas.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") _canvas.SetActive(false);
    }
}
