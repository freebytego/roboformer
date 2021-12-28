using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{
    private bool activated = false;
    public void Activate()
    {
        activated = true;
    }
    public void Deactivate()
    {
        activated = false;
    }
    public bool getState()
    {
        return activated;
    }
}
