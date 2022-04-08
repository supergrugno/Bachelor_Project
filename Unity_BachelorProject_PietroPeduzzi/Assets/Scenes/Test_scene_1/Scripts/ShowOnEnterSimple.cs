using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnEnterSimple : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    private void Start()
    {
        _canvas.SetActive(false);
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
