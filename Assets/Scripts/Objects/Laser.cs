using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Transform laserEnd;
    public int laserDamage = 5;

    private LineRender lineRender;
    private bool hitGoalObject = false;
    private bool wasTriggered = false;
    private void Start()
    {
        lineRender = GetComponent<LineRender>();
    }
    void Update()
    {
        lineRender.SetLineRenderer(false);
        RaycastHit2D[] hit = Physics2D.LinecastAll(transform.position, laserEnd.position);
        if (hit.Length > 1)
        {
            GameObject hitObject = hit[1].transform.gameObject;
            if (hitObject == laserEnd.transform.gameObject)
            {
                lineRender.DrawLine(transform.position, laserEnd.position);
                lineRender.SetLineRenderer(true);
                hitGoalObject = true;
            }
            else
            {
                if (hitObject.tag == "Player") hitObject.GetComponent<PlayerStatistics>().DealDamage(laserDamage);
                lineRender.DrawLine(transform.position, hitObject.transform.position);
                lineRender.SetLineRenderer(true);
                hitGoalObject = false;
            }
        }
        getState();
    }
    public void getState()
    {
        if (hitGoalObject)
        {
            GetComponent<Trigger>().Deactivate();
        }
        else
        {
            GetComponent<Trigger>().Activate();
        }
    }
}
