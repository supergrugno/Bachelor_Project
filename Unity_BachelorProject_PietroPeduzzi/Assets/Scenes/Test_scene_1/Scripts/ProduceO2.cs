using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceO2 : MonoBehaviour
{
    [SerializeField] private GameObject O2smokePS;
    [SerializeField] private AudioSource airSound;

    public void ProduceO2InBubble()
    {
        StaticValues.oxygenInBubble += 10;
        Debug.Log("added O2");
        Instantiate(O2smokePS, transform.position, Quaternion.identity);

        airSound.pitch = Random.Range(0.7f, 1.3f);
        airSound.Play();

    }
}
