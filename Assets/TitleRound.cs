using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleRound : MonoBehaviour
{
    public GameObject[] numbers;
    public int round = 1;
    public bool dontCountFirstRoundChange = false;

    public bool isShowingRound = true;
    public float timer = 0f;
    void Start()
    {
        round = 1;
        isShowingRound = true;
        dontCountFirstRoundChange = false;
    }

    void Update()
    {
        if (isShowingRound)
        {
            timer += Time.deltaTime;
            if (timer < 2)
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                numbers[round].gameObject.SetActive(true);   
            }
            else
            {
                isShowingRound = false;
                timer = 0;
                gameObject.GetComponent<Renderer>().enabled = false;
                numbers[round].gameObject.SetActive(false);
            }
        }
    }

    public void ChangeRound()
    {
        //if(dontCountFirstRoundChange)
            round += 1;
        //else
        //    dontCountFirstRoundChange = true;
    }
}
