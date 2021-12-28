using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelected : MonoBehaviour
{
    public float scaleFactor = 0.8f;
    public float lerpFactor = 0.1f;
    private Vector3 init_scale, small_scale;
    private void Start()
    {
        init_scale = transform.localScale;
        small_scale = init_scale * scaleFactor;
    }

    private void Update()
    {
        Deselected();
    }
    public void Selected()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, small_scale, lerpFactor);
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<HackController>().Hack_Button();
        }
    }
    public void Deselected()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, init_scale, lerpFactor);
    }
    private void OnMouseExit()
    {
        Deselected();
    }
}
