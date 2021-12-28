using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycasting : MonoBehaviour
{
    private Vector3 mousePosition, mouseDirection;
    private LineRender lineRender;
    private Movement movement;
    public bool isRayingMirror = false;
    private void Start()
    {
        lineRender = GetComponent<LineRender>();
        movement = GetComponent<Movement>();
    }
    void Update()
    {
        isRayingMirror = false;
        mousePosition = Input.mousePosition;
        mouseDirection = calculateDirection(mousePosition);
        lineRender.SetLineRenderer(false);
        if (movement.beingControled)
        {
            RaycastAll();
        }
    }

    void RaycastAll()
    {
        RaycastHit2D[] all_rays = Physics2D.RaycastAll(transform.position, mouseDirection);
        RaycastHit2D[] ray = new RaycastHit2D[3];
        if (all_rays.Length > 2)
        {
            int wallCount = 0;
            for (int i = 0; i < 3; i++)
            {
                ray[i] = all_rays[i];
                if (ray[i].collider.tag == "RayWall")
                {
                    wallCount++;
                }
                if (wallCount > 1) return;
            }
        }       
        if (ray.Length > 1)
        {
            if (ray[1].collider != null && ray[1].collider.tag == "RayWall")
            {
                Vector2 mousePositionByRay = (Vector2)Camera.main.ScreenToWorldPoint(mousePosition) - ray[1].point;
                int layermask = LayerMask.GetMask("SecondRaycast");
                RaycastHit2D ray_wall = Physics2D.Raycast(ray[1].point, mousePositionByRay, mousePositionByRay.magnitude, layermask);
                raycastCollision(ray_wall, mousePositionByRay, layermask, transform);
            }
        }
        
    }
    private void raycastCollision(RaycastHit2D hit, Vector2 mousePositionByRay, int layermask, Transform linePosition, bool fromMirror = false)
    {
        if (hit.collider != null)
        {
            switch (hit.collider.tag)
            {
                case "Movable":
                    checkLineDraw(fromMirror, linePosition, hit);
                    lineRender.SetLineRenderer(true);
                    hit.collider.GetComponent<MovableSelected>().Selected();
                    break;
                case "Enemy":
                    checkLineDraw(fromMirror, linePosition, hit);
                    lineRender.SetLineRenderer(true);
                    hit.collider.GetComponent<EnemySelected>().Selected();
                    break;
                case "RayRotator":
                    isRayingMirror = true;
                    checkLineDraw(fromMirror, linePosition, hit);
                    lineRender.SetLineRenderer(true);
                    GameObject rayRotator = hit.collider.gameObject;
                    if (!rayRotator.GetComponent<RayRotator>().isInUse)
                    {
                        
                        RaycastHit2D[] ray_mirror = Physics2D.RaycastAll(rayRotator.transform.position, rayRotator.transform.rotation * Vector2.right, mousePositionByRay.magnitude * 2f, layermask);
                        rayRotator.GetComponent<RayRotator>().isInUse = true;
                        if (ray_mirror.Length > 1)
                        {
                            rayRotator.GetComponent<LineRender>().DrawLine(rayRotator.transform.position, ray_mirror[1].point);
                            rayRotator.GetComponent<LineRender>().SetLineRenderer(true);
                            raycastCollision(ray_mirror[1], mousePositionByRay, layermask, rayRotator.transform, true);
                        }
                    }
                    break;
            }
        }
        else
        {
            isRayingMirror = false;
        }
    }

    private void checkLineDraw(bool fromMirror, Transform linePosition, RaycastHit2D hit)
    {
        if (!fromMirror)
            lineRender.DrawLine(linePosition.position, hit.collider.transform.position);
        else
        {
            linePosition.gameObject.GetComponent<LineRender>().DrawLine(linePosition.position, hit.collider.transform.position);
            linePosition.gameObject.GetComponent<LineRender>().SetLineRenderer(true);
        }
    }
    Vector3 calculateDirection(Vector3 vector)
    {
        Vector3 calcDir = Camera.main.ScreenToWorldPoint(vector);
        calcDir = calcDir - transform.position;
        return calcDir;
    }
}
