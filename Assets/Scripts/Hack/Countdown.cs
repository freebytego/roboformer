using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdown;
    public float timer = 15;
    private bool isCounting = true;

    void Update()
    {
        timer = Mathf.Clamp(timer, 0, timer);
        if (isCounting)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            } else
            {
                GetComponent<HackFinish>().Failed();
                timer = 0;
                isCounting = false;
            }
        }
        countdown.text = Mathf.FloorToInt(timer % 60).ToString();
    }
}
