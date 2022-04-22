using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigTargetScript : MonoBehaviour
{
    [SerializeField] private GameObject rigTargetMaxDistance;
    [SerializeField] private float legSwingDistance = 5f;
    [SerializeField] private float startDistance = 0;
    [SerializeField] private float footstepSpeed = 0.1f;

    private Vector3 slerpBeforeTransform;

    private void Start()
    {
        slerpBeforeTransform = new Vector3(rigTargetMaxDistance.transform.position.x + startDistance, rigTargetMaxDistance.transform.position.y, rigTargetMaxDistance.transform.position.z);
    }

    private void Update()
    {
        if(gameObject.transform.position.x - rigTargetMaxDistance.transform.position.x <= -legSwingDistance || gameObject.transform.position.x - rigTargetMaxDistance.transform.position.x >= legSwingDistance)
        {
            slerpBeforeTransform = rigTargetMaxDistance.transform.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, slerpBeforeTransform, footstepSpeed);
        //transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, slerpBeforeTransform.x, footstepSpeed), transform.position.y, transform.position.z);
    }
}
