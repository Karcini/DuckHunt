using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckChecker : MonoBehaviour
{
    public GameObject[] whiteDucks;
    public GameObject[] redDucks;
    public GameObject scoreKeeperInfo;

    public int ducksSpawned = 0; //increased on spawn in duckSpawner
    public int amountOfDucksShot = 0; // increased once duck was collected in scorekeeper

    void Start()
    {
        amountOfDucksShot = 0;
        ducksSpawned = 0;
    }

    void Update()
    {
        
    }

    public void DuckShot(int duckShot)
    {
        whiteDucks[duckShot].SetActive(false);
        redDucks[duckShot].SetActive(true);
    }

    public void NewSetOfDucks()
    {
        for (int x = 0; x < whiteDucks.Length; x++)
        {
            whiteDucks[x].SetActive(true);
            redDucks[x].SetActive(false);
        }
    }
}
