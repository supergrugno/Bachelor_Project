using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrainRotation : MonoBehaviour
{
    private Vector3 startVector;
    [SerializeField] private GameObject canvas;

    [SerializeField] private GameObject parentObj;
    private Rigidbody parentRB;

    [SerializeField] private LayerMask playerLayer;

    public bool checkX = false;
    private bool canvasIsActive;
    private bool canRaycast = false;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        startVector = transform.rotation.eulerAngles;
        canvas.SetActive(false);
        canvasIsActive = false;

        checkX = false;

        parentRB = parentObj.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(startVector);

        RaycastCheck();

        if (checkX && !canvasIsActive)
        {
            canvas.SetActive(true);
            canvasIsActive = true;
        }
        else if (!checkX && canvasIsActive)
        {
            canvas.SetActive(false);
            canvasIsActive = false;
        }
    }

    private void RaycastCheck()
    {
        if (canRaycast && !parentRB.isKinematic)
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out RaycastHit hitinfo, 1, playerLayer))
            {
                if (hitinfo.transform.tag == "Player") checkX = true;
                else if(hitinfo.transform.tag != "Player" || hitinfo.transform.gameObject == null )checkX = false;
            }
            if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.right), out RaycastHit hitinfo_2, 1, playerLayer))
            {
                if (hitinfo_2.transform.tag == "Player") checkX = true;
                else if (hitinfo_2.transform.tag != "Player" || hitinfo_2.transform.gameObject == null) checkX = false;
            }
        }else if(parentRB.isKinematic) checkX = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") canRaycast = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") canRaycast = false;
        checkX = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") canRaycast = true;
    }
}
