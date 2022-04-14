using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private int seconds;

    private void Start()
    {
        Destroy(gameObject, seconds);
    }
}
