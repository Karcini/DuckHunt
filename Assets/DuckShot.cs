using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckShot : MonoBehaviour
{
    //Instantiates the Duck falling animation after some time
    public float timer = 0;
    public GameObject duckFallPrefab;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Instantiate(duckFallPrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}
