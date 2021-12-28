using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Target;
    public float lerpFactor = 0.7f;
    public float mouseFactor = 5f;
    public float xOffset = 0f;
    public float yOffset = 0f;
    public bool isHolded = false;

    private Vector3 newPosition;
    private Vector3 mousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(2)) isHolded = !isHolded;
    }
    void FixedUpdate()
    {
        if (!isHolded) { 
            newPosition = Target.transform.position;
            newPosition.z = -10;
            newPosition.x = newPosition.x + xOffset;
            newPosition.y = newPosition.y + yOffset;
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) / mouseFactor;

        transform.position = Vector3.Lerp(transform.position, newPosition + mousePosition, lerpFactor);
    }
}
