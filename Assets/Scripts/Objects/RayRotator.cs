using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayRotator : MonoBehaviour
{
    public bool isInUse = false;
    private MouseRaycasting playerMRaycast;
    void Start()
    {
        playerMRaycast = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseRaycasting>();
    }
    void Update()
    {
        if (!playerMRaycast.isRayingMirror || !isInUse) GetComponent<LineRender>().SetLineRenderer(false);
        isInUse = false;
}
}
