using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRight : MonoBehaviour
{
    private bool num1, num2, num3;
    public void checkNumber()
    {
        num1 = transform.GetChild(0).GetChild(1).GetComponent<NumberSet>().checkState;
        num2 = transform.GetChild(0).GetChild(2).GetComponent<NumberSet>().checkState;
        num3 = transform.GetChild(0).GetChild(3).GetComponent<NumberSet>().checkState;
        if (num1 && num2 && num3) GetComponent<HackFinish>().Hack();
    }
}
