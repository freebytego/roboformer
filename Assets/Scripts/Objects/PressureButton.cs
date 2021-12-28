using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureButton : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Trigger>().Activate();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Trigger>().Deactivate();
    }
}
