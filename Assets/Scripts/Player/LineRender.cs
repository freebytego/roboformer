using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void DrawLine(Vector3 startpos, Vector3 endpos)
    {
        lineRenderer.SetPositions(new Vector3[2] { startpos, endpos });
    }
    public void SetLineRenderer(bool state)
    {
        lineRenderer.enabled = state;
    }
}
