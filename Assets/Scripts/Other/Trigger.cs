using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject targetTrigger;
    public void Activate()
    {
        if (targetTrigger != null)
            targetTrigger.GetComponent<ActivateTrigger>().Activate();
    }
    public void Deactivate()
    {
        if (targetTrigger != null)
            targetTrigger.GetComponent<ActivateTrigger>().Deactivate();
    }
}
