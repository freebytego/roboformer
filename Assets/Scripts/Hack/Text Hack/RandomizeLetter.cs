using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeLetter : MonoBehaviour
{
    string[] Alphabet = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    public string letter;
    void Start()
    {
        letter = Alphabet[Random.Range(0, Alphabet.Length)];
        transform.GetChild(0).GetComponent<Text>().text = letter;
    }
    public void SetChar(string character)
    {
        transform.GetChild(0).GetComponent<Text>().text = character;
    }
}
