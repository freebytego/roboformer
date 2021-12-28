using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberSet : MonoBehaviour
{
    public GameObject givenNumber;
    public bool checkState;
    private int givenNum, currentNum;
    void Start()
    {
        givenNum = Random.Range(0, 9);
        currentNum = Random.Range(0, 9);
        if (givenNum == currentNum) currentNum = Random.Range(0, 9);
        updateNumber();
    }
    void updateNumber()
    {
        if (currentNum > 9) currentNum = 0;
        if (currentNum < 0) currentNum = 9;
        checkState = checkNumber();
        GetComponent<Text>().text = currentNum.ToString();
        givenNumber.GetComponent<Text>().text = givenNum.ToString();
        transform.parent.parent.GetComponent<CheckRight>().checkNumber();
    }

    public void increaseNumber()
    {
        currentNum++;
        updateNumber();
    }
    public void decreaseNumber()
    {
        currentNum--;
        updateNumber();
    }
    bool checkNumber()
    {
        if (currentNum == givenNum)
        {
            GetComponent<Text>().color = Color.green;
            return true;
        } else
        {
            GetComponent<Text>().color = Color.white;
            return false;
        }
        
    }
}
