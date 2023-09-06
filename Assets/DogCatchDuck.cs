using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class DogCatchDuck : MonoBehaviour
{
    public GameObject[] dogCaught;
    public int howManyDucksCaught = 0;

    public float timer = 0;
    public float speed = 4f;

    public bool dogMovesUpNow = false;
    public bool dogLeftScene = false;
    public bool dogPickedUpDucks = false;
    void Start()
    {
        timer = 0;
        dogLeftScene = false;
        dogMovesUpNow = false;
        dogPickedUpDucks = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (dogPickedUpDucks==false)
        {
            dogCaught[howManyDucksCaught].SetActive(true);
            dogPickedUpDucks = true;
            dogMovesUpNow = true;
        }
        else if (gameObject.transform.position.y < -0.1 && dogMovesUpNow)
        {
            gameObject.transform.Translate(Vector3.up*Time.deltaTime*speed);
        }
        else if (timer > 2 && timer <2.5)
        {
            dogMovesUpNow = false;
            gameObject.transform.Translate(Vector3.down*Time.deltaTime*speed);
        }
        else if (timer > 2.5 && dogLeftScene==false)
        {
            gameObject.transform.Translate(0,0,2);
            dogLeftScene = true;
        }
    }
    
}
