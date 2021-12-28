using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWall : MonoBehaviour
{
    public float rotationSpeed = 20f;
    void Update()
    {
        this.transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }
}
