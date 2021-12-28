using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        Physics2D.CircleCast(transform.position, 10f, Vector2.zero);
    }
}
