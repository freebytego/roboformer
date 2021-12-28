using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackController : MonoBehaviour
{
    public GameObject hack_one;
    public GameObject hack_two;
    public float firstChance = 0.7f;
    public GameObject player;
    private bool wasHacked = false;
    public const float defHackCountdown = 15f;
    private float hackCountdown;

    private void Start()
    {
        hackCountdown = defHackCountdown;
    }
    private void Update()
    {
        if (getHackedState())
        {
            hackCountdown -= Time.deltaTime;
        }
        if (hackCountdown <= 0)
        {
            setHackedState(false);
            hackCountdown = defHackCountdown;
        }
    }
    public void Hack_Button()
    {
        player.GetComponent<Movement>().beingControled = false;
        player.GetComponent<PlayerStatistics>().isHacking = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().isHolded = false;
        if (Random.value <= firstChance)
        {
            GameObject hackMenu = Instantiate(hack_one);
            hackMenu.transform.parent = transform;
        } else
        {
            GameObject hackMenu = Instantiate(hack_two);
            hackMenu.transform.parent = transform;
        }
    }
    public bool getHackedState()
    {
        return wasHacked;
    }
    public void setHackedState(bool val)
    {
        wasHacked = val;
    }
}
