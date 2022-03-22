using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;

    public int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

        transform.position = Vector3.Lerp(transform.position, player.transform.position, interpolationRatio);

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)
    }
}
