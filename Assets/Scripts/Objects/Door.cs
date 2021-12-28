using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    void Update()
    {

        GetComponent<Collider2D>().enabled = !GetComponent<ActivateTrigger>().getState();
        GetComponent<Renderer>().enabled = !GetComponent<ActivateTrigger>().getState();
    }
}
