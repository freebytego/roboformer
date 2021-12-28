using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeLetter : MonoBehaviour
{
    public void Type()
    {
        string toType = transform.GetChild(0).GetComponent<Text>().text;
        GameObject.FindGameObjectWithTag("HackTextbox").GetComponent<InputField>().text += toType;
        checkComplete();
    }
    void checkComplete()
    {
        string textBox = GameObject.FindGameObjectWithTag("HackTextbox").GetComponent<InputField>().text;
        string label = GameObject.FindGameObjectWithTag("HackLabel").GetComponent<Text>().text;
        if (textBox == label)
        {
            transform.parent.parent.GetComponent<HackFinish>().Hack();
        }
    }
}
