using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool beingControled = true;
    public Rigidbody2D rb;
    public float speed = 100f;

    private Vector2 direction;

    private void FixedUpdate()
    {
        if (beingControled)
        {
            Moving();
        }
    }
    private void Moving()
    {
        direction.x = Mathf.Lerp(0, Input.GetAxis("Horizontal"), 0.7f);
        direction.y = Mathf.Lerp(0, Input.GetAxis("Vertical"), 0.7f);
        rb.velocity = direction * speed * Time.deltaTime;
    }
    public void SwitchControl()
    {
        if (!beingControled)
        {
            beingControled = true;
        }
        else if (beingControled)
        {
            beingControled = false;
            rb.velocity = Vector2.zero;
        }
    }

}
