using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoor : MonoBehaviour
{
    public void OpenDoor()
    {
        gameObject.GetComponent<Animator>().SetTrigger("DoorOpen");
    }
}
