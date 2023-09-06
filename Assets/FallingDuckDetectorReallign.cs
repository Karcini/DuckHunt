using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDuckDetectorReallign : MonoBehaviour
{
    public GameObject fallingDuckMain;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Duck")
        {
            fallingDuckMain.gameObject.GetComponent<FallingDuckDetector>().dogPosition = gameObject.transform.position;
            fallingDuckMain.gameObject.GetComponent<FallingDuckDetector>().dogRotation = gameObject.transform.rotation;
        }
    }
}
