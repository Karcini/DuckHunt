using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDuckDetector : MonoBehaviour
{
    public GameObject dogCatchPrefab;
    public GameObject scoreKeeperInfo;
    public int counter = 0;
    public int maxSet = 2;
    
    public Quaternion dogRotation = new Quaternion();
    public Vector3 dogPosition = new Vector3();
    void Start()
    {
        counter = 0;
        maxSet = scoreKeeperInfo.gameObject.GetComponent<ScoreKeeper>().ducksPerSet;
        dogPosition = gameObject.transform.position;
        dogRotation = gameObject.transform.rotation;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Duck")
        {
            dogPosition = other.gameObject.transform.position;
            dogRotation = other.gameObject.transform.rotation;
            dogPosition += new Vector3(0,0,-0.015f);
            counter += 1;
        }
    }

    public void RevealDog()
    {
        dogCatchPrefab.gameObject.GetComponent<DogCatchDuck>().howManyDucksCaught = counter;
        Instantiate(dogCatchPrefab, dogPosition, dogRotation);
        counter = 0;
    }
}
