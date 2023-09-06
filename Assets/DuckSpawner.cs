using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DuckSpawner : MonoBehaviour
{
    public GameObject[] duckSpawns;
    public GameObject duckPrefab;
    public GameObject scoreKeeperInfo;
    public GameObject duckHUD;
    public int randomSpawner;
    public int ducksPerSet = 1;
    public int ducksSpawned = 0;
    public float timer = 0f;
    
    void Start()
    {
        ducksPerSet = scoreKeeperInfo.gameObject.GetComponent<ScoreKeeper>().ducksPerSet;
        ducksSpawned = ducksPerSet;
        duckPrefab.gameObject.GetComponent<DuckFly>().currentDuck = 0;
    }

    void Update()
    {
        if (scoreKeeperInfo.gameObject.GetComponent<ScoreKeeper>().respawnDucks)
        {
            if (ducksSpawned >= ducksPerSet)
            {
                scoreKeeperInfo.gameObject.GetComponent<ScoreKeeper>().respawnDucks = false;
                ducksSpawned = 0;
                timer = 0;
            }
            timer += Time.deltaTime;
            if (timer > 2)
            {
                randomSpawner = Random.Range(0, duckSpawns.Length);
                Instantiate(duckPrefab, duckSpawns[randomSpawner].gameObject.transform.position, duckSpawns[randomSpawner].gameObject.transform.rotation);
                duckPrefab.gameObject.GetComponent<DuckFly>().currentDuck += 1;
                duckHUD.gameObject.GetComponent<DuckChecker>().ducksSpawned += 1;
                timer = 1;
                ducksSpawned += 1;
            }
        }
    }
}
