using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private Movement movement;
    private CameraFollow cameraFollow;
    public Movement playerMovement;
    private void Start()
    {
        movement = GetComponent<Movement>();
        cameraFollow = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }
    void Update()
    {
        if (movement.beingControled)
            stopControl();
    }
    private void stopControl()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SwitchControl();
        }
    }
    public void SwitchControl()
    {
        if (movement.beingControled)
        {
            movement.beingControled = false;
            playerMovement.beingControled = true;
            cameraFollow.Target = playerMovement.gameObject;
            cameraFollow.isHolded = false;
            playerMovement.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }
        else if (!movement.beingControled)
        {
            movement.beingControled = true;
            playerMovement.beingControled = false;
            cameraFollow.Target = gameObject;
            cameraFollow.isHolded = false;
            playerMovement.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
