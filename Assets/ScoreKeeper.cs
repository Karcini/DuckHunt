using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    //Responsible for...
        //Keeping Score
        //Deleting Duck
        //Keeping Round

    public float currentScore = 0;
    public int bestScore = 0;
    public int round = 1;
    public int ducksPerSet = 2;
    public int duckGone = 0;

    public GameObject dogSpawner;
    public GameObject duckSpawner;
    public bool respawnDucks = false;

    public float gunShotActivate = 0;
    public GameObject gunShot;
    public GameObject duckChecker;
    public GameObject duckPrefab;
    public int duckShot = 0;
    
    public GameObject fallingDuckDetector;
    public float duckDelayForFallingDucks = 0;
    public bool dogIsGatheringDucks = false;
    public bool dogGathersDucksOneFinalTime = true;

    public GameObject roundNumber;
    public GameObject titleRoundNumber;

    public float resetRoundTimer = 0f;
    public bool resetRound = false;

    public AudioSource gunShotSound;
    void Start()
    {
        currentScore = 0;
        respawnDucks = false;
        duckDelayForFallingDucks = 0;
        dogIsGatheringDucks = false;
        dogGathersDucksOneFinalTime = true;
        RestartSet(); // for now this will do
    }

    // Update is called once per frame
    void Update()
    {
        if (dogIsGatheringDucks)
        {
            duckDelayForFallingDucks += Time.deltaTime;
            if (duckDelayForFallingDucks > 3)
            {
                fallingDuckDetector.gameObject.GetComponent<FallingDuckDetector>().RevealDog();
                dogIsGatheringDucks = false;
                duckDelayForFallingDucks = 0;
            }
        }

        if (resetRound)
        {
            resetRoundTimer += Time.deltaTime;
            if (resetRoundTimer > 8)
            {
                //End of Round Process
                //reset round
                roundNumber.gameObject.GetComponent<Round>().ChangeRound();
                titleRoundNumber.gameObject.GetComponent<TitleRound>().ChangeRound();
                titleRoundNumber.gameObject.GetComponent<TitleRound>().isShowingRound = true;
                
                //reset duck checker
                duckChecker.gameObject.GetComponent<DuckChecker>().NewSetOfDucks();

                //reset gun
                gunShot.gameObject.GetComponent<GunShotDetector>().GunReload();
                
                //this leads to respawning ducks again
                dogSpawner.gameObject.GetComponent<DogSpawner>().RespawnWalkDog();

                duckShot= 0;
                duckChecker.gameObject.GetComponent<DuckChecker>().ducksSpawned = 0;
                RestartSet();
                duckPrefab.gameObject.GetComponent<DuckFly>().currentDuck =0;
                dogGathersDucksOneFinalTime = true;
                resetRound = false;
                resetRoundTimer = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //This duck will always meet scorekeeper for every instance of duck
            //This specific trigger detects two collisions per Duck due to making my hit box more accurate
        if (other.gameObject.tag == "LivingDuck")
        {
            duckGone += 1;
            
            //So this needs to detect if that duck was shot or not
            if (other.gameObject.GetComponent<DuckFly>().duckWasShot)
            {
                duckShot = other.gameObject.GetComponent<DuckFly>().currentDuck;
                duckChecker.gameObject.GetComponent<DuckChecker>().DuckShot(duckShot);
                currentScore += 0.5f;
                gunShotActivate += 0.5f;
                if (gunShotActivate >= 1f)
                {
                    gunShot.gameObject.GetComponent<GunShotDetector>().GunShot();
                    gunShotActivate = 0;
                }
            }
            
            
        }

        if (other.gameObject.tag == "Duck")
        {
            //This duck, will always be a duck that was shot
            duckChecker.gameObject.GetComponent<DuckChecker>().amountOfDucksShot+= 1;
        }

        if (other.gameObject.tag == "Dog")
        {
            if (duckPrefab.gameObject.GetComponent<DuckFly>().currentDuck + 1 <
                duckChecker.gameObject.GetComponent<DuckChecker>().whiteDucks.Length)
            {
                respawnDucks = true;
                gunShot.gameObject.GetComponent<GunShotDetector>().GunReload();   
            }
        }
        
        if (duckGone == ducksPerSet*2)
        {
            if (duckPrefab.gameObject.GetComponent<DuckFly>().currentDuck + 1 <
                duckChecker.gameObject.GetComponent<DuckChecker>().whiteDucks.Length)
            {
                dogIsGatheringDucks = true;
                RestartSet();   
            }
            else if(dogGathersDucksOneFinalTime)
            {
                dogIsGatheringDucks = true;
                dogGathersDucksOneFinalTime = false;
            }
            else
            {
                //End of Round Process
                resetRound = true;
            }
        }
        Destroy(other.gameObject);
    }

    void RestartSet()
    {
        duckGone = 0;
        duckSpawner.gameObject.GetComponent<DuckSpawner>().ducksSpawned = 0;
        duckChecker.gameObject.GetComponent<DuckChecker>().amountOfDucksShot = 0;
    }
    
}
