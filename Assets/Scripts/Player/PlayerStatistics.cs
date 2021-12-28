using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatistics : MonoBehaviour
{
    public int health = 150;
    public bool isHacking = false;

    public void Start()
    {
        UpdateAll();
    }
    public void DealDamage(int amount)
    {
        health -= amount;
        UpdateAll();
    }
    public void RegenerateHealth(int amount)
    {
        health += amount;
        UpdateAll();
    }

    public void UpdateAll()
    {
        if (health <= 0) {
            print("rip in the chat");
        }
    }
}
