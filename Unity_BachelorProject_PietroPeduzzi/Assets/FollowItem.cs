using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowItem : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    private GameObject itemToFollow;
    private bool itemArrived = false;

    private void Start()
    {
        _canvas.SetActive(false);
    }
    private void Update()
    {
        if(itemArrived) transform.position = itemToFollow.transform.position;

        if (itemArrived && itemToFollow.GetComponent<Rigidbody>().isKinematic == true) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PickUpObject")
        {
            itemToFollow = other.gameObject;
            itemArrived = true;
            _canvas.SetActive(true);
        }
    }
}
