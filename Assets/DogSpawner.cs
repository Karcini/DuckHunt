using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class DogSpawner : MonoBehaviour
{
    public GameObject dogWalkPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RespawnWalkDog()
    {
        Instantiate(dogWalkPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
