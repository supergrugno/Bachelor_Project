using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour
{
    private LineRenderer thisLineRenderer;

    [SerializeField] private Transform lineStart;
    [SerializeField] private Transform lineEnd;

    private void Start()
    {
        thisLineRenderer = this.gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        thisLineRenderer.SetPosition(0, lineStart.position);
        thisLineRenderer.SetPosition(1, lineEnd.position);
    }
}
