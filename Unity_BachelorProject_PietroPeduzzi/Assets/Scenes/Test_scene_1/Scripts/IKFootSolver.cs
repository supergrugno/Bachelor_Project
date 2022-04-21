using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKFootSolver : MonoBehaviour
{
    public Transform body;
    public float footSpacing = 1;
    public LayerMask terrainLayer;

    private void Update()
    {
        Ray ray = new Ray(body.position + (body.right * footSpacing), Vector3.down);
        if(Physics.Raycast(ray, out RaycastHit info, 10, terrainLayer.value))
        {
            transform.position = info.point;
        }
    }
}
