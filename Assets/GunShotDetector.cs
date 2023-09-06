using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShotDetector : MonoBehaviour
{
    public int bulletCount = 3;
    public float timer = 1f;
    public GameObject[] bulletPrefab;
    public GameObject gunShootPreventer;
    void Start()
    {
        bulletCount = 3;
        timer = 1;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 1)
        {
            if (timer > .1)
            {
                gameObject.transform.GetComponent<Renderer>().enabled = false;   
            }
        }

        if (bulletCount <= 0)
        {
            gunShootPreventer.gameObject.SetActive(true);
        }
    }
    void OnMouseDown()
    {
        GunShot();
    }

    public void GunShot()
    {
        if (bulletCount > 0)
        {
            bulletCount -= 1;
            gameObject.transform.GetComponent<Renderer>().enabled = true;
            //Gunshot Sound
            timer = 0;

            bulletPrefab[bulletCount].gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    public void GunReload()
    {
        bulletCount = 3;
        gunShootPreventer.gameObject.SetActive(false);
        for (int x = 0; x < bulletPrefab.Length; x++)
        {
            bulletPrefab[x].gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
