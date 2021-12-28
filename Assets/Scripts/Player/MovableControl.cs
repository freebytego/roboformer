using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovableControl : MonoBehaviour
{
    public bool beingControled = false;
    public float speed = 500f;

    public GameObject player;
    public Rigidbody2D rb;

    private void Update()
    {
        if (beingControled)
        {
            Moving();
        }
    }
    private void Moving()
    {

        if (Input.GetMouseButtonDown(1))
        {
            SwitchControl();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * speed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(Vector2.down * speed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed * Time.deltaTime);
        }
    }
    public void SwitchControl()
    {
        if (beingControled)
        {
            beingControled = false;
            player.GetComponent<Movement>().SwitchControl();
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }
        else if (!beingControled)
        {
            beingControled = true;
            player.GetComponent<Movement>().SwitchControl();
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject collider = collision.collider.gameObject;
        if (collider.tag == "Player")
        {
            collider.GetComponent<PlayerStatistics>().DealDamage(5);
        }
        
        
    }

}
