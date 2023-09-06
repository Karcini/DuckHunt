using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    public GameObject[] numbers;
    public int round = 1;
    public bool dontCountFirstRoundChange = false;
    void Start()
    {
        round = 1;
        dontCountFirstRoundChange = false;
    }

    void Update()
    {
        
    }

    public void ChangeRound()
    {
        numbers[round].SetActive(false);
        round += 1;
        numbers[round].SetActive(true);
    }
}
