using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeAnimation : MonoBehaviour
{
    [SerializeField] private float maxSize = 2;
    [SerializeField] private float minSize = 0.5f;

    [SerializeField] private float speed = 1;

    private float actualSize = 1;
    private bool growing = true;

    private void Update()
    {
        if (growing)
        {
            gameObject.transform.localScale = Vector3.MoveTowards(gameObject.transform.localScale, new Vector3(maxSize, maxSize, maxSize), speed);
            actualSize = gameObject.transform.localScale.x;

            if (actualSize >= maxSize) growing = false;
        }else if (!growing)
        {
            gameObject.transform.localScale = Vector3.MoveTowards(gameObject.transform.localScale, new Vector3(minSize, minSize, minSize), speed);
            actualSize = gameObject.transform.localScale.x;

            if (actualSize <= minSize) growing = true;
        }
    }

}
