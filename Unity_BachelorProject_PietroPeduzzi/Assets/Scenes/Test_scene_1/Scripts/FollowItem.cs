using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowItem : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    private GameObject itemToFollow;

    private void Start()
    {
        _canvas.SetActive(false);
    }
    private void Update()
    {
        gameObject.transform.position = itemToFollow.transform.position;
        _canvas.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PickUpObject")
        {
            itemToFollow = other.gameObject;
            _canvas.SetActive(true);
        }
    }
}
