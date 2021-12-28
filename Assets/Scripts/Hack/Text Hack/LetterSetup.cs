using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.WSA;
using Random = UnityEngine.Random;

public class LetterSetup : MonoBehaviour
{
    public string[] words = { "ely","free","byte","apt","get","inst" };
    public Text textToType;
    private GameObject[] letterButtons;
    private ArrayList Spots = new ArrayList();

    private void Start()
    {
        StartCoroutine(LateStart());
    }
    string AddWordButtons()
    {
        int randomSpot = 0;
        int randPrep = 0;
        letterButtons = GameObject.FindGameObjectsWithTag("HackLetter");
        string randWord = words[Random.Range(0, words.Length)];
        char[] randLetters = randWord.ToCharArray();
        for (int j = 0; j < randLetters.Length;) {
            randomSpot = 0;
            randPrep = Random.Range(0, letterButtons.Length);
            if (!Spots.Contains(randPrep))
            {
                randomSpot = randPrep;
                Spots.Add(randomSpot);
                j++;
            }
        }
        for (int i = 0; i < randLetters.Length; i++)
        {
            letterButtons[(int)Spots[i]].GetComponent<RandomizeLetter>().SetChar(randLetters[i].ToString().ToUpper());
        }
        return randWord;
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(5/1000);
        string pickedWord = AddWordButtons().ToUpper();
        textToType.text = pickedWord;
    }
}
