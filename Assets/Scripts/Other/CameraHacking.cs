using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHacking : MonoBehaviour
{
    private PlayerStatistics playerStatistics;
    private float defaultSize;
    public float zoomedSize = 10;
    public float lerpZoom = 0.1f;
    public float lerpBack = 0.1f;

    void Start()
    {
        playerStatistics = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatistics>();
        defaultSize = GetComponent<Camera>().orthographicSize;
    }

    void Update()
    {
        if (playerStatistics.isHacking)
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, zoomedSize, lerpZoom);
        } else
        {
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, defaultSize, lerpBack);
        }
    }
}
